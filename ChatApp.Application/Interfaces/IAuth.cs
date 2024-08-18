using ChatApp.Application.DTOs.Auth;

namespace ChatApp.Application.Interfaces;

public interface IAuth
{
  Task<MessageResponse> Register(RegisterRequest request);
  Task<MessageResponse> Login(LoginRequest request);
}
