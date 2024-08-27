using ChatApp.Application.DTOs.Message;
using ChatApp.Application.Interfaces;
using ChatApp.Infrastructure.Cache;
using ChatApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Web.Controllers;

public class ChatController : Controller
{
  private readonly IChat _chat;
  private readonly IMessage _message;
  private ChatModel _model;
  private Redis _redis;

  public ChatController(IChat chat, IMessage message, Redis redis)
  {
    _chat = chat;
    _message = message;
    _redis = redis;
    _model = new ChatModel();
  }

  [Route("Chat/")]
  public async Task<IActionResult> Index()
  {
    string email = await _redis.GetString("login-email");
    _model.Auth = await _chat.GetUserByEmail(email);

    _model.Users = await _chat.GetAllUsers();

    return View(_model);
  }

  [HttpGet]
  [Route("Chat/{accountId}")]
  public async Task<IActionResult> ChatRoom(string accountId)
  {
    _model.User = await _chat.GetUser(accountId);
    return Json(_model.User);
  }

  // [HttpGet]
  // [Route("Chat/{accountId}")]
  // public async Task<IActionResult> Chatting(string accountId)
  //{
  //   _model.User = await _chat.GetUser(accountId);
  //   return View(_model);
  // }

  [HttpPost]
  //[Route("Chat/Send/")]
  public async Task<IActionResult> SendMessage(MessageRequest req)
  {
    var msg = await _message.SendMessage(req);
    return Json(msg);
  }
}
