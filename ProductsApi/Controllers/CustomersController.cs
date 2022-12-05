using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Models;
using ProductsAPI.Models.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace ProductsAPI.Controllers;

[ApiController]
[Route("/api/cart")]
[Produces("application/json")]
public class CustomersController : ControllerBase
{
	private readonly ApiDbContext _context;
	// private readonly ILogger<CustomersController> _logger;

	public CustomersController(ApiDbContext context)
	{
		_context = context;
		// _logger = logger;
	}

	[HttpGet]
	[SwaggerOperation(Summary = "Get customer cart")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCartResDto))]
	public async Task<IActionResult> GetCart()
	{
		// TODO: when user is logged in, get cart by user id and set session 
		GetCartResDto getCartResDto = await GetCartWithCartItemsAndSession();
		return Ok(getCartResDto);
	}

	[HttpPatch("add-cartitem/{productId}")]
	[SwaggerOperation(Summary = "Add cart item to cart")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> AddCartItem(int productId)
	{
		Cart cart = await GetCartAndSession();
		// check if product exists
		Product? product = await _context.Products.FindAsync(productId);
		if (product is null)
			return NotFound();
		CartItem? cartItem = await _context.CartItems
	  .Where(ci => ci.CartId == cart.CartId && ci.ProductId == productId)
	  .FirstOrDefaultAsync();
		if (cartItem == null)
		{
			cartItem = new CartItem
			{
				Quantity = 1,
				ProductId = productId,
				CartId = cart.CartId
			};
			_ = _context.CartItems.Add(cartItem);
		}
		else
		{
			cartItem.Quantity++;
		}
		_ = await _context.SaveChangesAsync();
		return Ok();
	}

	[HttpPatch("remove-one-cartitem/{productId}")]
	[SwaggerOperation(Summary = "Remove one cart item from cart")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> RemoveOneCartItem(int productId)
	{
		Cart cart = await GetCartAndSession();
		CartItem? cartItem = await _context.CartItems.Where(ci => ci.CartId == cart.CartId && ci.ProductId == productId).FirstOrDefaultAsync();
		if (cartItem != null)
		{
			if (cartItem.Quantity > 1)
			{
				cartItem.Quantity--;
			}
			else
			{
				_ = _context.CartItems.Remove(cartItem);
			}
			_ = await _context.SaveChangesAsync();
		}
		else
		{
			return NotFound();
		}

		return Ok();
	}

	[HttpPut("remove-cartitem/{productId}")]
	[SwaggerOperation(Summary = "Remove cart item from cart")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> RemoveCartItem(int productId)
	{
		Cart cart = await GetCartAndSession();
		CartItem? cartItem = await _context.CartItems
		.Where(ci => ci.CartId == cart.CartId && ci.ProductId == productId)
		.FirstOrDefaultAsync();
		if (cartItem != null)
		{
			_ = _context.CartItems.Remove(cartItem);
			_ = await _context.SaveChangesAsync();
		}
		else
		{
			return NotFound();
		}

		return Ok();
	}

	/// <summary>
	/// Gets cart from session or creates a new session with a new cart if session is null
	/// </summary>
	/// <returns>
	/// Cart from session or new cart
	/// </returns>
	private async Task<Cart> GetCartAndSession()
	{
		string? sessionId = HttpContext.Session.GetString("sessionId");
		if (sessionId == null)
		{
			sessionId = Guid.NewGuid().ToString();
			HttpContext.Session.SetString("sessionId", sessionId);
		}
		// var cart = await _context.Carts.FirstOrDefaultAsync(c => c.SessionId == sessionId);
		Cart? cart = await _context.Carts.Where(c => c.SessionId == sessionId).FirstOrDefaultAsync();
		if (cart == null)
		{
			cart = new Cart
			{
				SessionId = sessionId
			};
			_ = _context.Carts.Add(cart);
			_ = await _context.SaveChangesAsync();
		}
		return cart;
	}

	private async Task<GetCartResDto> GetCartWithCartItemsAndSession()
	{
		string? sessionId = HttpContext.Session.GetString("sessionId");
		if (sessionId == null)
		{
			sessionId = Guid.NewGuid().ToString();
			HttpContext.Session.SetString("sessionId", sessionId);
		}
		GetCartResDto? getCartResDto;
		getCartResDto = await _context.Carts
		  .Include(c => c.CartItems)
		  .Where(c => c.SessionId == sessionId)
		  .Select(c => new GetCartResDto
		  {
			  CartId = c.CartId,
			  SessionId = c.SessionId,
			  CartItems = c.CartItems == null ? new List<GetCartResDtoCartItem>() : c.CartItems.Select(ci => new GetCartResDtoCartItem
			  {
				  CartItemId = ci.CartItemId,
				  Quantity = ci.Quantity,
				  ProductId = ci.ProductId,
				  Product = new GetCartResDtoCartItemProduct
				  {
					  ProductId = ci.Product.ProductId,
					  Title = ci.Product.Title,
					  Description = ci.Product.Description,
					  Price = ci.Product.Price,
					  DiscountPercentage = ci.Product.DiscountPercentage,
					  Rating = ci.Product.Rating,
					  Stock = ci.Product.Stock,
					  Brand = ci.Product.Brand,
					  Category = ci.Product.Category,
					  ImageUrl = ci.Product.ImageUrl
				  },
				  CartId = ci.CartId,
				  DateCreated = ci.DateCreated,
				  DateUpdated = ci.DateUpdated
			  }).ToList(),
			  CustomerId = c.CustomerId,
			  Customer = c.Customer == null ? null : new() { CustomerId = c.Customer.CustomerId }
		  }).FirstOrDefaultAsync();

		// In case of no cart associated with the session id create a new cart
		Cart cart;
		if (getCartResDto == null)
		{
			cart = new Cart
			{
				SessionId = sessionId
			};
			_ = _context.Carts.Add(cart);
			_ = await _context.SaveChangesAsync();
			getCartResDto = new GetCartResDto
			{
				CartId = cart.CartId,
				SessionId = cart.SessionId,
				CartItems = new List<GetCartResDtoCartItem>()
			};
		}

		return getCartResDto;
	}
}