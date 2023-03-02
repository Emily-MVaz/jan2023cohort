using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;
public class ResultController : Controller
{
  [HttpGet("/result")]
  public ViewResult Result()
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
}
