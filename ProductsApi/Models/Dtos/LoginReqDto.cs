using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dtos;

public class LoginReqDto
{
	/// <example>testuserproductsadmin@localhost</example>
	[Required]
	[EmailAddress]
	public string Email { get; set; } = null!;
	/// <example>testuserproductsadmin</example> 
	[Required]
	// regex for password with min 8 characters, max 32, 1 uppercase, 1 lowercase, 1 number, 1 special character
	// [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$", ErrorMessage = "Password must be 8-32 characters long, contain at least 1 uppercase, 1 lowercase, 1 number, and 1 special character.")]
	[StringLength(36, MinimumLength = 6)] // for dev
	public string Password { get; set; } = null!;
}