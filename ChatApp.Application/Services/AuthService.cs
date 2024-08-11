using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Services;

internal class AuthService : IAuth
{
    public Task<User> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }
     
    public Task<RegisterResponse> Register(RegisterRequest request)
    {
        throw new NotImplementedException();
    }
}
