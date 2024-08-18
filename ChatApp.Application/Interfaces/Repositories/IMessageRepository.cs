using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;

namespace ChatApp.Application.Interfaces.Repositories;

public interface IMessageRepository
{
  Task<CrudResults> AddMessage(Message msg);
  Task<List<Message>> GetMessages(string userId);
  Task<CrudResults> DeleteMessage(string msgId);
}
