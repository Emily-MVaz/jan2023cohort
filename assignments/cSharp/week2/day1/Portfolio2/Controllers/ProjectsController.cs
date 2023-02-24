using Microsoft.AspNetCore.Mvc;

namespace ProjectsController.Controllers;

public class ProjectsController : Controller
{
  [HttpGet("projects")]

  public ViewResult Projects()
  {
    return View("Projects");
  }
}
