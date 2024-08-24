using ChatApp.Application.Interfaces;
using ChatApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Web.Controllers;

public class ChatController : Controller
{
  private readonly IChat _chat;
  ChatModel model = new ChatModel();

  public ChatController(IChat chat)
  {
    _chat = chat;
  }


  [Route("Chat/")]
  public async Task<IActionResult> Index()
  {
    model.Users = await _chat.GetAllUsers();
    return View(model);
  }

  [HttpGet]
  [Route("Chat/{accountId}")]
  public async Task<IActionResult> Chat(string accountId)
  {
    model.User = await _chat.GetUser(accountId);
    return Json(model.User);
  }
}
