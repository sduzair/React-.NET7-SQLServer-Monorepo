using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models;

public class CartItem : IAuditable
{
	public int CartItemId { get; set; }
	[Range(1, 1000)]
	public required int Quantity { get; set; }
	public required int ProductId { get; set; }
	public Product Product { get; set; } = null!;
	public required int CartId { get; set; }
	public Cart Cart { get; set; } = null!;
	public DateTimeOffset DateCreated { get; set; }
	public DateTimeOffset? DateUpdated { get; set; }
	public DateTimeOffset? DateDeleted { get; set; }
}


