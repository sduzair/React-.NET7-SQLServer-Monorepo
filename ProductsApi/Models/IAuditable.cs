namespace ProductsAPI.Models;

public interface IAuditable
{
  public DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset? DateUpdated { get; set; }
  public DateTimeOffset? DateDeleted { get; set; }
}