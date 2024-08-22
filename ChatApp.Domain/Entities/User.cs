using ChatApp.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatApp.Domain.Entities;

public class User
{
  [BsonId]
  public string Id { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public DateTime DoB { get; set; }
  [BsonRepresentation(BsonType.String)]
  public Gender Gender { get; set; }
  public string Password { get; set; }
}
