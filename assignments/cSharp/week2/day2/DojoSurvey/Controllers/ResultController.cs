using Microsoft.AspNetCore.Mvc;

namespace ResultController.Controllers;
public class ResultController : Controller
{
  [HttpGet("result")]
  public ViewResult Result()
  {
    return View("Result");
  }
}

