using ChatApp.Application.DTOs;
using ChatApp.Application.Interfaces;
using ChatApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Web.Controllers;

public class ChatController : Controller
{
  private readonly IChat _chat;
  private ChatModel _model;

  public ChatController(IChat chat)
  {
    _chat = chat;
    _model = new ChatModel();
  }

  [Route("Chat/")]
  public async Task<IActionResult> Index(UserDTO user)
  {
    _model.Auth = user;

    _model.Users = await _chat.GetAllUsers();

    return View(_model);
  }

  [HttpGet]
  [Route("Chat/{accountId}")]
  public async Task<IActionResult> Chat(string accountId)
  {
    _model.User = await _chat.GetUser(accountId);
    return Json(_model.User);
  }
}
