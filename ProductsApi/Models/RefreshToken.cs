namespace ProductsAPI.Models;

public class RefreshToken
{
  public int RefreshTokenId { get; set; }
  public required string Token { get; set; }
  public required string JwtId { get; set; }
  public required bool IsRevoked { get; set; }
  public required DateTime CreationDate { get; set; }
  public required DateTime ExpiryDate { get; set; }
  public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
  public bool IsActive => !IsExpired;
  public string UserId { get; set; } = null!;
  public User User { get; set; } = null!;
}