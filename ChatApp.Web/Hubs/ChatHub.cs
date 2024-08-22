using ChatApp.Application.DTOs.Message;
using ChatApp.Application.Interfaces;
using ChatApp.Domain.Enums;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Web.Hubs;

public class ChatHub : Hub
{
  private readonly IMessage _message;

  public ChatHub(IMessage message)
  {
    _message = message;
  }

  public async Task SendMessage(string sender, string reveiver, string message)
  {
    var msgDTO = new MessageRequest()
    {
      Content = message,
      MessageType = MessageType.Text,
      SenderId = sender,
      ReceiverId = reveiver
    };

    await _message.SendMessage(msgDTO);
    await Clients.User(reveiver).SendAsync("ReceiveMessage", sender, message);
    //await Clients.All.SendAsync("ReceiveMessage", user, message);
  }
}
