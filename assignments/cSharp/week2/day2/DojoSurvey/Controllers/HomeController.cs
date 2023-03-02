using Microsoft.AspNetCore.Mvc;

namespace ResultController.Controllers;
public class HomeController : Controller
{
  [HttpGet("")]
  public ViewResult Index()
  {
    return View("Index");
  }
}

