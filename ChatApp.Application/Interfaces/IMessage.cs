using ChatApp.Application.DTOs;
using ChatApp.Application.DTOs.Message;

namespace ChatApp.Application.Interfaces;

public interface IMessage
{
  Task SendMessage(MessageRequest request);
  Task<List<MessageDTO>> GetMessages(string userId);
  Task DeleteMessage(string msgId);
}
