using ChatApp.Domain.Enums;

namespace ChatApp.Application.DTOs.Message;

public class MessageRequest
{
  public string Content { get; set; }
  public MessageType MessageType { get; set; }
  public string SenderId { get; set; }
  public string ReceiverId { get; set; }
}
