using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.DTOs.Auth;

public class MessageResponse
{
    public bool IsSuccess { get; set; }   
    public string Message { get; set; }

    public MessageResponse SuccessMessage(string message)
    {
        IsSuccess = true;
        Message = message;
        return this;
    }

    public MessageResponse ErrorMessage(string message)
    {
        IsSuccess = false;
        Message = message;
        return this;
    }
}
