using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Models;

public class Product : IAuditable
{
	public int ProductId { get; set; }
	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	[Column(TypeName = "decimal(18,2)")]
	public decimal Price { get; set; }
	[Column(TypeName = "decimal(4,2)")]
	public decimal DiscountPercentage { get; set; }
	// [Column(TypeName = "double")]
	public double Rating { get; set; }
	public int Stock { get; set; }
	public string Brand { get; set; } = null!;
	public string Category { get; set; } = null!;
	[Column(TypeName = "varchar(200)")]
	public string ImageUrl { get; set; } = null!;
	public List<CartItem>? CartItem { get; set; }
	public DateTimeOffset DateCreated { get; set; }
	public DateTimeOffset? DateUpdated { get; set; }
	public DateTimeOffset? DateDeleted { get; set; }
}