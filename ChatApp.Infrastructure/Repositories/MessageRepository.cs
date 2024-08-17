using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;
using ChatApp.Infrastructure.Db;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly IMongoCollection<Message> _messagesCollection;

    public MessageRepository(MongoDbConnection mongo)
    {
        _messagesCollection = mongo.GetCollection<Message>("messages");
    }

    public async Task<CrudResults> AddMessage(Message msg)
    {
        await _messagesCollection.InsertOneAsync(msg);
        return CrudResults.Success;
    }

    public async Task<CrudResults> DeleteMessage(string msgId)
    {
        var filter = Builders<Message>.Filter.Eq(msg => msg.Id, msgId);
        var result = await _messagesCollection.DeleteOneAsync(filter);

        if (result.DeletedCount > 0)
        {
          return CrudResults.Success;
        }
        return CrudResults.Fail;
    }

    public async Task<List<Message>> GetMessages(string userId)
    {
        var filter = Builders<Message>.Filter.Or(
          Builders<Message>.Filter.Eq(msg => msg.SenderId, userId),
          Builders<Message>.Filter.Eq(msg => msg.ReceiverId, userId)
          );

        return await _messagesCollection.Find(filter).ToListAsync();
    }
}
