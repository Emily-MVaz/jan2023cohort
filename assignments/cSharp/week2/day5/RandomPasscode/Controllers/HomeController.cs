using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    HttpContext.Session.SetInt32("number", 1);
    int count = Convert.ToInt32(HttpContext.Session.GetInt32("number"));
    return View(count);
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

  [HttpGet("generate")]
  public IActionResult Generate()
  {
    int count = Convert.ToInt32(HttpContext.Session.GetInt32("number"));
    count++;
    HttpContext.Session.SetInt32("number", count);
    return View("Index", count);  
  }

}
