using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dtos;

public class PutProductReqDto
{
    public string? Title { get; set; }  
    public string? Description { get; set; }
    [Range(0.01, 1000000.00)]
    [DataType(DataType.Currency)]
    public decimal? Price { get; set; }
    [Range(0.00, 1.00)]
    public decimal? DiscountPercentage { get; set; }
    [Range(0.00, 5.00)]
    public double? Rating { get; set; }
    [Range(0, 1000000)]
    public int? Stock { get; set; }
    public string? Brand { get; set; }
    public string? Category { get; set; }
    [DataType(DataType.ImageUrl)]
    public string? ImageUrl { get; set; }
}
