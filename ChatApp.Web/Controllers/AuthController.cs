using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatApp.Web.Controllers;

public class AuthController : Controller
{
  private readonly IAuth _auth;

  public AuthController(IAuth auth)
  {
    _auth = auth;
  }

  public async Task<IActionResult> Login()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginRequest req)
  {
    if (!ModelState.IsValid)
    {
      return View(req);
    }

    var response = await _auth.Login(req);
    TempData["Message"] = JsonConvert.SerializeObject(response);

    if (!response.IsSuccess)
    {
      return View();
    }
    return View("~/Views/Chat/Index.cshtml");
  }

  public async Task<IActionResult> Register()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Register(RegisterRequest req)
  {

    if (!ModelState.IsValid)
    {
      return View(req);
    }

    var response = await _auth.Register(req);

    TempData["Message"] = JsonConvert.SerializeObject(response);

    if (!response.IsSuccess)
    {
      return View();
    }
    return View("Login");
  }
}
