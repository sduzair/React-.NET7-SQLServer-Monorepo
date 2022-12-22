using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Models.Config;
using ProductsAPI.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductsAPI.Controllers;

[ApiController]
[Route("/api/auth")]
[Produces("application/json")]
public class AuthController : ControllerBase
{
	private readonly IConfiguration _config;
	private readonly UserManager<User> _userManager;
	private readonly SignInManager<User> _signInManager;
	// private readonly RoleManager<IdentityRole> _roleManager;
	private readonly ApiDbContext _context;
	private readonly TokenValidationParameters _tokenValidationParameters;
	private readonly List<RoleConfig> _roles;

	public AuthController(IConfiguration config,
		UserManager<User> userManager,
		SignInManager<User> signInManager,
		// RoleManager<IdentityRole> roleManager,
		ApiDbContext context,
		TokenValidationParameters tokenValidationParameters,
		List<RoleConfig> roles)
	{
		_config = config;
		_userManager = userManager;
		_signInManager = signInManager;
		// _roleManager = roleManager;
		_context = context;
		_tokenValidationParameters = tokenValidationParameters;
		_roles = roles;
	}

	[HttpPost("register")]
	[SwaggerOperation(Summary = "Register a new user21")]
	[ProducesResponseType(StatusCodes.Status201Created)]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
	public async Task<IActionResult> Register(RegisterReqDto registerReqDto)
	{
		registerReqDto.Email = registerReqDto.Email.ToLower(System.Globalization.CultureInfo.CurrentCulture);
		if (await _userManager.FindByEmailAsync(registerReqDto.Email) != null)
		{
			return CustomBadRequest(nameof(registerReqDto.Email), new List<string>() { "Email already exists" });
		}

		if (await _userManager.FindByNameAsync(registerReqDto.UserName) != null)
			return CustomBadRequest(nameof(registerReqDto.UserName), new List<string>() { "Username already exists" });

		User userToCreate = new()
		{
			Email = registerReqDto.Email,
			UserName = registerReqDto.UserName,
			RoleName = registerReqDto.RoleName
		};
		IdentityResult result = await _userManager.CreateAsync(userToCreate, registerReqDto.Password);
		if (result.Succeeded)
		{
			// add user to role if it exists in roles array
			RoleConfig? role = _roles.Find(r => r.Name == registerReqDto.RoleName);
			if (role != null)
			{
				_ = await _userManager.AddToRoleAsync(userToCreate, role.Name);
			}
			return StatusCode(201);
		}
		return CustomBadRequest("Register", result.Errors.Select(e => e.Description).ToList());
	}

	[HttpPost("login")]
	[SwaggerOperation(Summary = "Login a user. Returns an Access Token along with a Refresh Token.")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JWTTokenResDto))]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	public async Task<IActionResult> Login(LoginReqDto loginReqDto)
	{
		User? user = await _userManager.FindByEmailAsync(loginReqDto.Email);
		if (user == null)
			return Unauthorized();

		Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginReqDto.Password, false);
		if (result.Succeeded)
		{
			SecurityToken token = await GenerateJwtToken(user);
			return Ok(new JWTTokenResDto
			{
				AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
				RefreshToken = (await GenerateAndStoreRefreshToken(token, user)).Token,
				Expiration = token.ValidTo
			});
		}
		return Unauthorized();
	}

	// logout user by deleting refresh token
	[HttpPost("logout")]
	[Authorize(Roles = "Customer,ProductsAdmin")]
	[SwaggerOperation(Summary = "Logout a user. Deletes the Refresh Token.")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
	public async Task<IActionResult> Logout(LogoutReqDto logoutReqDto)
	{
		RefreshToken? refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == logoutReqDto.RefreshToken);
		if (refreshToken == null)
			return CustomBadRequest(nameof(logoutReqDto.RefreshToken), new List<string>() { "Refresh token not found" });

		_ = _context.RefreshTokens.Remove(refreshToken);
		_ = await _context.SaveChangesAsync();
		return Ok();
	}

	[HttpPost("refresh-token")]
	[SwaggerOperation(Summary = "Refreshes the expired Access Token if the Refresh Token has not expired. Generates a new Refresh Token if the old one has expired.")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JWTTokenResDto))]
	[ProducesResponseType(StatusCodes.Status401Unauthorized)]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
	public async Task<IActionResult> RefreshToken(RefreshTokenReqDto refreshTokenReqDto)
	{
		RefreshToken? savedRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshTokenReqDto.RefreshToken);
		if (savedRefreshToken == null)
			return Unauthorized();
		// implentation of refresh token login that checks if the refresh token has been revoked previously
		User? user = await _userManager.FindByIdAsync(savedRefreshToken.UserId);
		if (user == null)
			return Unauthorized();

		JwtSecurityTokenHandler jwtTokenHandler = new();
		try
		{
			_ = jwtTokenHandler.ValidateToken(refreshTokenReqDto.AccessToken, _tokenValidationParameters, out SecurityToken validatedToken);
			if (validatedToken is JwtSecurityToken jwtSecurityToken)
			{
				if (jwtSecurityToken.ValidTo > DateTime.UtcNow)
					return CustomBadRequest(nameof(refreshTokenReqDto.AccessToken), new List<string>() { "Access token has not expired yet" });
			}
		}
		catch (SecurityTokenExpiredException)
		{
			SecurityToken token = await GenerateJwtToken(user);
			if (savedRefreshToken.ExpiryDate >= DateTime.UtcNow)
			{
				return Ok(new JWTTokenResDto
				{
					AccessToken = jwtTokenHandler.WriteToken(token),
					RefreshToken = refreshTokenReqDto.RefreshToken,
					Expiration = token.ValidTo
				});
			}
			else
			{
				// We assume that Refresh Tokens are secure and can be used to generate new Access Tokens and Refresh Tokens
				return Ok(new JWTTokenResDto
				{
					AccessToken = jwtTokenHandler.WriteToken(token),
					RefreshToken = (await GenerateAndStoreRefreshToken(token, user)).Token,
					Expiration = token.ValidTo
				});
			}
		}
		catch (Exception)
		{
			return Unauthorized();
		}

		return Unauthorized();
	}

	// <summary>
	// For getting the identity of the user from the expired token. Not needed when we have the refresh token in the database. Returns null if the token is invalid.
	// </summary>
	// <param name="token"></param>
	// <returns></returns>
	// private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
	// {
	//   var tokenValidationParameters = _tokenValidationParameters.Clone();
	//   tokenValidationParameters.ValidateLifetime = false;
	//   var tokenHandler = new JwtSecurityTokenHandler();
	//   try
	//   {
	//     var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
	//     return !IsJwtWithValidSecurityAlgorithm(validatedToken) ? null : principal;
	//   }
	//   catch
	//   {
	//     return null;
	//   }
	// }

	// private static bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
	// {
	//   return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
	//     jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
	// }

	/// <summary>
	/// Generates JWT Access Token with claims, expiration, signing credentials, issuer and audience. Returns the new Access Token and expiration.
	/// </summary>
	/// <param name="user"></param>
	/// <returns></returns>
	private async Task<SecurityToken> GenerateJwtToken(User user)
	{

		List<Claim> claims = new()
		{
			new Claim(ClaimTypes.NameIdentifier, user.Id),
			new Claim(ClaimTypes.Name, user.UserName!),
			new Claim(ClaimTypes.Email, user.Email!),
			new Claim(JwtRegisteredClaimNames.Email, user.Email!),
			new Claim(JwtRegisteredClaimNames.Sub, user.Email!),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		};

		IList<string> roles = await _userManager.GetRolesAsync(user);
		foreach (string role in roles)
		{
			claims.Add(new Claim(ClaimTypes.Role, role));
		}

		SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Secret").Value!));
		SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha512Signature);
		SecurityTokenDescriptor tokenDescriptor = new()
		{
			Subject = new ClaimsIdentity(claims),
			Expires = DateTime.UtcNow.AddMinutes(60),
			SigningCredentials = creds,
			Issuer = _config.GetSection("JWT:Issuer").Value,
			Audience = _config.GetSection("JWT:Audience").Value
		};
		JwtSecurityTokenHandler tokenHandler = new();
		SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
		return securityToken;
	}

	/// <summary>
	/// Generates a long lived refresh token and saves it in the database. Returns the refresh token.
	/// </summary>
	/// <param name="securityToken"></param>
	/// <param name="user"></param>
	/// <returns></returns>
	private async Task<RefreshToken> GenerateAndStoreRefreshToken(SecurityToken securityToken, User user)
	{
		RefreshToken refreshToken = new()
		{
			Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString(),
			JwtId = securityToken.Id,
			UserId = user.Id,
			CreationDate = DateTime.Now,
			ExpiryDate = DateTime.Now.AddMonths(6),
			IsRevoked = false,
		};
		_ = await _context.RefreshTokens.AddAsync(refreshToken);
		_ = await _context.SaveChangesAsync();

		return refreshToken;
	}

	private BadRequestObjectResult CustomBadRequest(string key, List<string> values)
	{
		Dictionary<string, string[]> errors = new()
		{
			{ key, values.ToArray() }
		};
		return BadRequest(new ValidationProblemDetails(errors));
	}
}

internal class JWTTokenResDto
{
	public required string AccessToken { get; set; }
	public required string RefreshToken { get; set; }
	public required DateTime Expiration { get; set; }
}
