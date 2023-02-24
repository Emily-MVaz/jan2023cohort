using Microsoft.AspNetCore.Mvc;

namespace ContactController.Controllers;

public class ContactController : Controller
{
  [HttpGet("contact")]

  public ViewResult Contact()
  {
    return View("Contact");
  }
}