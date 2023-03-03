using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurveyValidation.Models;

namespace DojoValidation.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
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

  [HttpGet("/result")]
  public IActionResult ViewResult()
  {
    return View("result");
  }

  [HttpPost("/result")]
  public IActionResult CreateUser(string name, string location, string language, string comment)
  {
    ViewBag.Name = $"{name}";
    ViewBag.Location = $"{location}";
    ViewBag.Language = $"{language}";
    ViewBag.Comment = $"{comment}";

    return View("result");
  }


  [HttpGet("result")]
  public IActionResult AUser()
  {
    Result newResult = new Result(){
        name = "emily",
        Location = location,

        
  };
  return View(newResult);
}
