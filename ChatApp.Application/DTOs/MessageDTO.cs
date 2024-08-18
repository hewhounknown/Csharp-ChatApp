using ChatApp.Domain.Enums;

namespace ChatApp.Application.DTOs;

public class MessageDTO
{
  public string Id { get; set; }
  public string Content { get; set; }
  public MessageType MessageType { get; set; }
  public DateTime Sent { get; set; }
  public string SenderId { get; set; }
  public string ReceiverId { get; set; }
}
