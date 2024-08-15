using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.Interfaces;
using ChatApp.Application.Mappings;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Services;

internal class AuthService : IAuth
{
    private readonly IUserRepository _userRepository;

    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> Login(LoginRequest request)
    {
        throw new NotImplementedException();
    }
     
    public async Task<RegisterResponse> Register(RegisterRequest request)
    {
        var isExited = await _userRepository.FindAccountByEmail(request.Email);
        if (isExited == CrudResults.AlreadyExisted)
        {
            return new RegisterResponse().ErrorMessage("there is an account using this email");
        }

        if(request.Password != request.ConfirmPassword)
        {
            return new RegisterResponse().ErrorMessage("please, make passwords are the same!");
        }

        var res = await _userRepository.CreateAccount(request.Map());
        if(res == CrudResults.Fail)
        {
            return new RegisterResponse().ErrorMessage("something wrong, can't create account!");
        }

        return new RegisterResponse().SuccessMessage("registered successful");
    }

}
 