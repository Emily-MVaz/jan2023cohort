using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;
public class HomeController : Controller
{
  [HttpGet("")]
  public ViewResult Index()
  {
    return View();
  }
}