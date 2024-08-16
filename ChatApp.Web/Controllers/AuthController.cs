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

  public async Task<IActionResult> LoginPage()
  {
    return View();
  }

  public async Task<IActionResult> Login()
  {
    return View();
  }

  public async Task<IActionResult> RegisterPage()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Register(RegisterRequest req)
  {
    MessageResponse res = await _auth.Register(req);

    if( res.Success is false)
    {
      return View("/Auth/RegisterPage");
    }
    return View("/Auth/LoginPage");
  }
}
