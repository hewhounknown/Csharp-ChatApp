using ChatApp.Application.Interfaces.Repositories;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Enums;
using ChatApp.Infrastructure.Db;
using MongoDB.Driver;

namespace ChatApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
  private readonly IMongoCollection<User> _usersCollection;

  public UserRepository(MongoDbConnection mongo)
  {
    _usersCollection = mongo.GetCollection<User>("users");
  }

  public async Task<CrudResults> CreateAccount(User user)
  {
    await _usersCollection.InsertOneAsync(user);
    return CrudResults.Success;
  }

  public async Task<CrudResults> DeleteAccount(string accountId)
  {
    var filter = Builders<User>.Filter.Eq(u => u.Id, accountId);
    var result = await _usersCollection.DeleteOneAsync(filter);

    if (result.DeletedCount > 0)
    {
      return CrudResults.Success;
    }
    return CrudResults.Fail;
  }

  public async Task<User> FindAccountByEmail(string email)
  {
    var filter = Builders<User>.Filter.Eq(u => u.Email, email);
    return await _usersCollection.Find(filter).FirstOrDefaultAsync();
  }

  public async Task<User> FindAccountById(string accountId)
  {
    var filter = Builders<User>.Filter.Eq(u => u.Id, accountId);
    return await _usersCollection.Find(filter).FirstOrDefaultAsync();
  }

  public async Task<List<User>> GetAllAccounts()
  {
    return await _usersCollection.Find(user => true).ToListAsync();
  }

  public async Task<CrudResults> UpdateAccount(User user)
  {
    var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
    var result = await _usersCollection.ReplaceOneAsync(filter, user);

    if (result.ModifiedCount > 0)
    {
      return CrudResults.Success;
    }
    return CrudResults.Fail;
  }
}
