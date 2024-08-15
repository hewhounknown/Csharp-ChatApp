using ChatApp.Application.DTOs.Auth;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
