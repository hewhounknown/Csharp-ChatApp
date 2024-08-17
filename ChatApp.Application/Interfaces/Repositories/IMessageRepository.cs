using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces.Repositories;

public interface IMessageRepository
{
    Task<CrudResults> AddMessage(Message msg);
    Task<List<Message>> GetMessages(string userId);
    Task<CrudResults> DeleteMessage(string msgId);
}
