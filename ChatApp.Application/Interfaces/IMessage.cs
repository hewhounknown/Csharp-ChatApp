using ChatApp.Application.DTOs;
using ChatApp.Application.DTOs.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces;

public interface IMessage
{
    Task SendMessage(MessageRequest request);
    Task<List<MessageDTO>> GetMessages(string userId);
    Task DeleteMessage(string msgId);
}
