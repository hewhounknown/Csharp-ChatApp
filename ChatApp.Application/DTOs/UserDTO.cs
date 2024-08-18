using ChatApp.Domain.Enums;

namespace ChatApp.Application.DTOs;

public class UserDTO
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public DateTime DoB { get; set; }
  public Gender Gender { get; set; }
  public string Password { get; set; }
}
