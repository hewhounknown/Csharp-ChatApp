using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Web.Controllers;

public class AuthController : Controller
{
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

  public async Task<IActionResult> Register()
  {
    return View();
  }
}
