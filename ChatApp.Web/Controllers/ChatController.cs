using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Web.Controllers;

public class ChatController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
