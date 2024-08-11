using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.DTOs.Auth;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces;

public interface IAuth
{
    Task<RegisterResponse> Register(RegisterRequest request);
    Task<User> Login(LoginRequest request);
}
