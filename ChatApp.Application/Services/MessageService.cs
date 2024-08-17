using ChatApp.Application.DTOs;
using ChatApp.Application.DTOs.Message;
using ChatApp.Application.Interfaces;
using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Application.Mappings;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Services;

public class MessageService : IMessage
{
    private readonly IMessageRepository _messageRepository;

    public MessageService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public Task DeleteMessage(string msgId)
    {
      throw new NotImplementedException();
    }

    public async Task<List<MessageDTO>> GetMessages(string userId)
    {
        var msgList = await _messageRepository.GetMessages(userId);

        var dtoList = msgList.Select(msg => msg.Map()).ToList();
        return dtoList;
    }

    public async Task SendMessage(MessageRequest request)
    {
        Message msg = request.Entity();
        await _messageRepository.AddMessage(msg);
    }

}
