using ChatApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Application.DTOs.Auth;

public class RegisterRequest
{
  [Required]
  public string Name { get; set; }

  [Required]
  [EmailAddress]
  public string Email { get; set; }

  public string? Phone { get; set; }

  [Required]
  public DateTime DoB { get; set; }

  [Required]
  public Gender Gender { get; set; }

  [Required]
  [MinLength(6)]
  public string Password { get; set; }

  [Required]
  [Compare("Password")]
  public string ConfirmPassword { get; set; }
}
