using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DateValidator.Models;

namespace DateValidator.Controllers;

public class DateController : Controller
{
  [HttpGet("")]
  public IActionResult Index()
  {
    return View();
  }

  [HttpGet("chooseDate")]
  public IActionResult ChooseDate(Date date)
  {
    if (ModelState.IsValid)
    {
      return View("ViewDate", date);
    }
    return View("Index");
  }

  [HttpGet("viewDate")]
  public IActionResult ViewDate()
  {
    return View();
  }
}
