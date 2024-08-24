using ChatApp.Application.DTOs;

namespace ChatApp.Application.Interfaces;

public interface IChat
{
  Task<List<UserDTO>> GetAllUsers();
  Task<UserDTO> GetUser(string accountId);
  Task<UserDTO> GetUserByEmail(string email);
}
