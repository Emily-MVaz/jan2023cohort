using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoValidation.Models;
namespace DojoSurvey.Controllers;
public class HomeController : Controller
{
  [HttpGet("/result")]
  public IActionResult Result()
  {
    return View("result");
  }


  [HttpPost("/viewResult")]
  
  public IActionResult CreateUser(Result newResult)
  {
      if(!ModelState.IsValid){
      return View("Index");
    }
    // Console.WriteLine($"My name is {newResult.Name}, the dojo is in {newResult.Location}, my favorite language is {newResult.Language}, My comments are: {newResult.Comment}");
    return View("viewResult", newResult);
  }

  [HttpGet("/viewResult")]
  public IActionResult ViewResult()
  {
    // ViewBag.Name = "em";
    // ViewBag.Location = "here :)";
    // ViewBag.Language = "english";
    // ViewBag.Comment = "This is a comment";

    //! replacing view bag
    Result myResult = new Result()
    {
      Name = "me",
      Location = "there :)",
      Language = "benglish",
      Comment = "This is a comment :)"
    };
    return View("viewResult", myResult);
  }
}


