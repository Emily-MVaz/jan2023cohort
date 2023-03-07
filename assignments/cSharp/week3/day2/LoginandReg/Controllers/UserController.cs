using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using LoginandReg.Models;

namespace LoginandReg.Controllers;

public class UserController : Controller
{

  private MyContext _context;

  public UserController(MyContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  public IActionResult Index()
  {
    return View("Index");
  }

  [SessionCheck]
  [HttpGet("success")]
  public IActionResult Success()
  {
    return View("success");
  }

  [HttpPost("/register")]
  public IActionResult Register(User user)
  {
    if (!ModelState.IsValid)
    {
      return View("Index");
    }
    PasswordHasher<User> Hasher = new PasswordHasher<User>();
    user.Password = Hasher.HashPassword(user, user.Password);

    _context.Users.Add(user);
    _context.SaveChanges();
    HttpContext.Session.SetInt32("UserId", user.UserId);
    return RedirectToAction("success");
  }

  [HttpPost("/login")]
  public IActionResult Login(LoginUser getUser)
  {
    if (!ModelState.IsValid)
    {
      return View("Index");
    }
    else
    {
      User? userInDb = _context.Users.FirstOrDefault(u => u.Email == getUser.LoginEmail);
      if (userInDb == null)
      {
        ModelState.AddModelError("LoginEmail", "Invalid Email");
        return View("Index");
      }
      else
      {
        PasswordHasher<LoginUser> hash = new PasswordHasher<LoginUser>();
        var result = hash.VerifyHashedPassword(getUser, userInDb.Password, getUser.LoginPassword);
        if (result == 0)
        {
          ModelState.AddModelError("LoginPassword", "Invalid Password");
          return View("Index");
        }
        else
        {
          HttpContext.Session.SetInt32("UserId", userInDb.UserId);
          HttpContext.Session.SetString("FirstName", userInDb.FirstName);
          return RedirectToAction("success");
        }
      }
    }
  }

  [HttpPost("/logout")]
  public IActionResult Logout()
  {
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
  }

  public class SessionCheckAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      int? userId = context.HttpContext.Session.GetInt32("UserId");
      if (userId == null)
      {
        context.Result = new RedirectToActionResult("Index", "User", null);
      }
    }
  }
}