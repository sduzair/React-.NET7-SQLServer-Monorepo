using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dtos;

// /products - POST req - add product
public class PostProductReqDto
{
  [Required]
  public string Title { get; set; } = null!;    // setting required modifier causes JSON deserialization to fail and [Required] attribute to be ignored
  [Required]
  public string Description { get; set; } = null!;
  [Required]
  [Range(0.01, 1000000.00)]
  [DataType(DataType.Currency)]
  public decimal? Price { get; set; }   // property has to be nullable for [Required] attribute to work because without making it nullable property is initialized with default value and escapes model validation
  [Required]
  [Range(0.00, 1.00)]
  public decimal? DiscountPercentage { get; set; }
  [Required]
  [Range(0.00, 5.00)]
  public double? Rating { get; set; }
  [Required]
  [Range(0, 1000000)]
  public int? Stock { get; set; }
  [Required]
  public string Brand { get; set; } = null!;
  [Required]
  public string Category { get; set; } = null!;
  [Required]
  [DataType(DataType.ImageUrl)]
  public string ImageUrl { get; set; } = null!;
}