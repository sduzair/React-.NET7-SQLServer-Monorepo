using Microsoft.AspNetCore.Identity;

namespace ProductsAPI.Models;

public class User : IdentityUser, IAuditable
{
  // public int UserId { get; set; }
  // public required string Email { get; set; }
  // public required byte[] PasswordHash { get; set; }
  // public required byte[] PasswordSalt { get; set; }
  public Customer? Customer { get; set; }
  public ProductAdmin? Product { get; set; }
  public DateTimeOffset DateCreated { get; set; }
  public DateTimeOffset? DateUpdated { get; set; }
  public DateTimeOffset? DateDeleted { get; set; }
  public required string RoleName { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
  public string? Address { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? Zip { get; set; }
  public string? Country { get; set; }
}