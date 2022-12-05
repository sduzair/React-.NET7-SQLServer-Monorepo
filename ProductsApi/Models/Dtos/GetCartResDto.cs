namespace ProductsAPI.Models.Dtos;

public class GetCartResDto
{
  public required int CartId { get; set; }
  public required string SessionId { get; set; }
  public required List<GetCartResDtoCartItem> CartItems { get; set; }
  public int? CustomerId { get; set; }
  public GetCartResDtoCustomer? Customer { get; set; }
}

public class GetCartResDtoCartItem
{
  public required int CartItemId { get; set; }
  public required int Quantity { get; set; }
  public required int ProductId { get; set; }
  public required GetCartResDtoCartItemProduct Product { get; set; }
  public required int CartId { get; set; }
  public required DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset? DateUpdated { get; set; }
}

public class GetCartResDtoCustomer
{
  public int CustomerId { get; set; }
}

public class GetCartResDtoCartItemProduct
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
}