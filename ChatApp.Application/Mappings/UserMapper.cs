using ChatApp.Application.DTOs.Auth;
using ChatApp.Domain.Entities;

namespace ChatApp.Application.Mappings;

public static class UserMapper
{
  public static User Map(this RegisterRequest request)
  {
    return new User()
    {
      Name = request.Name,
      Email = request.Email,
      Phone = request.Phone,
      DoB = request.DoB,
      Gender = request.Gender,
      Password = request.Password,
    };
  }
}
