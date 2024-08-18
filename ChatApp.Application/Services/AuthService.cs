using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.Interfaces;
using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Application.Mappings;
using ChatApp.Domain.Enums;

namespace ChatApp.Application.Services;

public class AuthService : IAuth
{
  private readonly IUserRepository _userRepository;

  public AuthService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<MessageResponse> Login(LoginRequest request)
  {
    var user = await _userRepository.FindAccountByEmail(request.Email);

    if (user == null || user.Password != request.Password)
    {
      return new MessageResponse().ErrorMessage("Email or password is incorrect, try again");
    }

    return new MessageResponse().SuccessMessage("Login Success");
  }

  public async Task<MessageResponse> Register(RegisterRequest request)
  {
    var isExited = await _userRepository.FindAccountByEmail(request.Email);
    if (isExited != null)
    {
      return new MessageResponse().ErrorMessage("there is an account using this email");
    }

    if (request.Password != request.ConfirmPassword)
    {
      return new MessageResponse().ErrorMessage("please, make passwords are the same!");
    }

    var res = await _userRepository.CreateAccount(request.Map());
    if (res == CrudResults.Fail)
    {
      return new MessageResponse().ErrorMessage("something wrong, can't create account!");
    }

    return new MessageResponse().SuccessMessage("registered successful");
  }

}
