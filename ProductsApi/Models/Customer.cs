namespace ProductsAPI.Models;

public class Customer : IAuditable
{
	public int CustomerId { get; set; }
	public string UserId { get; set; } = null!;
	public User User { get; set; } = null!;
	// Cart not null there's a cart created for every user customer
	public Cart Cart { get; set; } = null!;
	public DateTimeOffset DateCreated { get; set; }
	public DateTimeOffset? DateUpdated { get; set; }
	public DateTimeOffset? DateDeleted { get; set; }
}