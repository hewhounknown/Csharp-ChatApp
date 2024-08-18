using System.ComponentModel.DataAnnotations;

namespace ChatApp.Application.DTOs.Auth;

public class ForgetPasswordRequest
{
  [Required]
  [EmailAddress]
  public string Email { get; set; }
}
