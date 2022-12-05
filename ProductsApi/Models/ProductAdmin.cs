namespace ProductsAPI.Models;

public class ProductAdmin : IAuditable
{
  public int ProductAdminId { get; set; }
  public string UserId { get; set; } = null!;
  public User User { get; set; } = null!;
  public DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset? DateUpdated { get; set; }
  public DateTimeOffset? DateDeleted { get; set; }
}