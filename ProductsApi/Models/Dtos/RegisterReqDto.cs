using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Models.Dtos;

public class RegisterReqDto
{
  [Required]
  [EmailAddress]    // has the regex that validates email address
  // [DataType(DataType.EmailAddress)]   // format displayed in MVC view
  public string Email { get; set; } = null!;
  [Required]
  // regex for username wiht letters and numbers only 
  [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Username can only contain letters and numbers.")]
  [StringLength(10, MinimumLength = 6)] // for dev
  public string UserName { get; set; } = null!;
  [Required]
  // regex for password with min 8 characters, max 32, 1 uppercase, 1 lowercase, 1 number, 1 special character
  // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$", ErrorMessage = "Password must be 8-32 characters long, contain at least 1 uppercase, 1 lowercase, 1 number, and 1 special character.")]
  [StringLength(36, MinimumLength = 6)] // for dev
  public string Password { get; set; } = null!;
  [Required]
  [Compare("Password", ErrorMessage = "Passwords do not match")]
  public string ReenterPassword { get; set; } = null!;
  [Required]
  public string RoleName { get; set; } = null!;
}