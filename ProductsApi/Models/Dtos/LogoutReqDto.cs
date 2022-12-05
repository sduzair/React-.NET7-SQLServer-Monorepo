using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dtos;

public class LogoutReqDto
{
  [Required]
  public string RefreshToken { get; set; } = null!;
}