using ChatApp.Domain.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatApp.Domain.Entities;

public class Message
{
  [BsonId]
  public string Id { get; set; }
  public string Content { get; set; }
  [BsonRepresentation(BsonType.String)]
  public MessageType MessageType { get; set; }
  public DateTime Sent { get; set; }
  public string SenderId { get; set; }
  public string ReceiverId { get; set; }
}
