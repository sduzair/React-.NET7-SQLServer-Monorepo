namespace ProductsAPI.Models;

public class Cart : IAuditable
{
  public int CartId { get; set; }
  public required string SessionId { get; set; }
  public List<CartItem>? CartItems { get; set; }
  public int? CustomerId { get; set; }
  public Customer? Customer { get; set; }
  public DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset? DateUpdated { get; set; }
  public DateTimeOffset? DateDeleted { get; set; }
}