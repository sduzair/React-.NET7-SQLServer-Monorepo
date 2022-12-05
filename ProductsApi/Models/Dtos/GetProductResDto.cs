namespace ProductsAPI.Models.Dtos;

// /products/{id} - GET - res body
// /products - GET - res body
// /products/{id} - PUT - req body
public class GetProductResDto : IAuditable
{
  public required int ProductId { get; set; }
  public required string Title { get; set; }
  public required string Description { get; set; }
  public required decimal Price { get; set; }
  public required decimal DiscountPercentage { get; set; }
  public required double Rating { get; set; }
  public required int Stock { get; set; }
  public required string Brand { get; set; }
  public required string Category { get; set; }
  public required string ImageUrl { get; set; }
  public DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset? DateUpdated { get; set; }
  public DateTimeOffset? DateDeleted { get; set; }
}