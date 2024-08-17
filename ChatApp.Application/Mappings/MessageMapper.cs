using ChatApp.Application.DTOs;
using ChatApp.Application.DTOs.Message;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Mappings;

public static class MessageMapper
{
    public static Message Entity(this MessageRequest request)
    {
        return new Message
        {
            Id = Guid.NewGuid().ToString(),
            Content = request.Content,
            MessageType = request.MessageType,
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId,
            Sent = DateTime.Now
        };
    }
    public static MessageDTO Map(this Message msg)
    {
        return new MessageDTO()
        {
            Id = msg.Id,
            Content = msg.Content,
            MessageType = msg.MessageType,
            Sent = msg.Sent,
            SenderId = msg.SenderId,
            ReceiverId = msg.ReceiverId,
        };
    }
}
