using ChatApp.Application.DTOs;

namespace ChatApp.Web.Models;

public class ChatModel
{
  public List<UserDTO> Users { get; set; }
  public UserDTO User { get; set; }
  public UserDTO Auth { get; set; }

}
