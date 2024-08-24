using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Application.Mappings;

namespace ChatApp.Application.Services;

public class ChatService : IChat
{
  private readonly IUserRepository _userRepository;

  public ChatService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<List<UserDTO>> GetAllUsers()
  {
    var lst = await _userRepository.GetAllAccounts();
    List<UserDTO> userDTOs = lst.Select(user => user.Map()).ToList();
    return userDTOs;
  }

  public async Task<UserDTO> GetUser(string accountId)
  {
    var user = await _userRepository.FindAccountById(accountId);
    return user.Map();
  }
}
