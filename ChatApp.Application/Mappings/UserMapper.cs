using ChatApp.Application.DTOs;
using ChatApp.Application.DTOs.Auth;
using ChatApp.Domain.Entities;

namespace ChatApp.Application.Mappings;

public static class UserMapper
{
  public static User Entity(this RegisterRequest request)
  {
    return new User()
    {
      Id = Guid.NewGuid().ToString(),
      Name = request.Name,
      Email = request.Email,
      Phone = request.Phone,
      DoB = request.DoB,
      Gender = request.Gender,
      Password = request.Password,
    };
  }

  public static UserDTO Map(this User user)
  {
    return new UserDTO()
    {
      Id = user.Id,
      Name = user.Name,
      Email = user.Email,
      Phone = user.Phone,
      DoB = user.DoB,
      Gender = user.Gender,
      Password = user.Password,
    };
  }
}
