using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey.Controllers;
public class ResultController : Controller
{

  [HttpGet("/result")]
  public IActionResult Result()
  {
    User newUser = new User()
    {
      Name = "emily",
      Location = "location",
      Language = "abc",
      Comment = "abc123465464"


    };
    return View(newUser);
  }


}


