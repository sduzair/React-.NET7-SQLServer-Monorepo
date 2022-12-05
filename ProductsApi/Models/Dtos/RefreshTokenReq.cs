using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dtos;

public class RefreshTokenReqDto
{
  [Required]
  public string AccessToken { get; set; } = null!;
  [Required]
  public string RefreshToken { get; set; } = null!;
}