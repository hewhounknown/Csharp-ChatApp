using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Web.Controllers;

public class ChatController : Controller
{
  private readonly IChat _chat;

  public ChatController(IChat chat)
  {
    _chat = chat;
  }

  public async Task<IActionResult> Index()
  {
    List<UserDTO> userList = await _chat.GetAllUsers();
    return View(userList);
  }
}
