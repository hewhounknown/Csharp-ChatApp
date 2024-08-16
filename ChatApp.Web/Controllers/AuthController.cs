using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    if (ModelState.IsValid)
    {
      return View(req);
    }
    return View();
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

    return View("Login");
  }
}
