using MongoDB.Driver;

namespace ChatApp.Infrastructure.Db;

public class MongoDbConnection
{
  private readonly IMongoDatabase _database;

  public MongoDbConnection(string connectionString, string databaseName)
  {
    var client = new MongoClient(connectionString);
    _database = client.GetDatabase(databaseName);
  }

  public IMongoCollection<T> GetCollection<T>(string collectionName)
  {
    return _database.GetCollection<T>(collectionName);
  }
}
