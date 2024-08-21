using ChatApp.Application.DTOs.Auth;
using ChatApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatApp.Web.Controllers;

public class AuthController : Controller
{
  private readonly IAuth _auth;
  private readonly ILogger<AuthController> _logger;

  public AuthController(IAuth auth, ILogger<AuthController> logger)
  {
    _auth = auth;
    _logger = logger;
  }

  public async Task<IActionResult> Login()
  {
    _logger.LogInformation("Accessed Login page.");
    TempData.Clear();
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Login(LoginRequest req)
  {
    if (!ModelState.IsValid)
    {
      _logger.LogWarning("Required valid infromation to login success.");
      return View(req);
    }

    var response = await _auth.Login(req);
    TempData["Message"] = JsonConvert.SerializeObject(response);

    if (!response.IsSuccess)
    {
      _logger.LogWarning($"{req.Email} - login failed.");
      return View();
    }

    _logger.LogInformation($"{req.Email} - log in success.");
    return RedirectToAction("Index", "Chat");
  }

  public async Task<IActionResult> Register()
  {
    _logger.LogInformation("Accessed Register page");
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> Register(RegisterRequest req)
  {

    if (!ModelState.IsValid)
    {
      _logger.LogWarning("Required Valid informaion to register");
      return View(req);
    }

    var response = await _auth.Register(req);

    TempData["Message"] = JsonConvert.SerializeObject(response);

    if (!response.IsSuccess)
    {
      _logger.LogWarning($"{req.Email} - register failed.");
      return View();
    }

    _logger.LogInformation($"{req.Email} - registered success.");
    return Redirect("/Auth/Login");
  }
}
