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

  public async Task<IActionResult> Index()
  {
    model.Users = await _chat.GetAllUsers();
    return View(model);
  }

  public async Task<IActionResult> Chat(string accountId)
  {
    model.User = await _chat.GetUser(accountId);
    return View("Index", model);
  }
}
