using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.DTOs.Auth;

public class RegisterResponse
{
    public bool Success { get; set; }   
    public string Message { get; set; }

    public RegisterResponse SuccessMessage(string message)
    {
        Success = true;
        Message = message;
        return this;
    }

    public RegisterResponse ErrorMessage(string message)
    {
        Success = false;
        Message = message;
        return this;
    }
}
