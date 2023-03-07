using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class DishController : Controller
{
  private MyContext _context;

  public DishController(MyContext context)
  {
    _context = context;
  }

  //* CREATE
  [HttpGet("/dishes/new")]
  public IActionResult New()
  {
    return View("addDish");
  }

  [HttpPost("/dish/create")]
  public IActionResult Create(Dish dish)
  {
    if (!ModelState.IsValid)
    {
      return View("addDish");
    }
    _context.Dishes.Add(dish);
    _context.SaveChanges();
    Console.WriteLine($"{dish.Name} has been added!");
    return RedirectToAction("new");
  }

  //* READ  
  [HttpGet("/dishes/{dishId}")]
  public IActionResult ViewDish(int dishId)
  {
    Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    if (dish is null)
    {
      return RedirectToAction("Index", "Home");
    }
    return View("ViewDish", dish);
  }


  //* UPDATE
  [HttpGet("/dishes/{dishId}/edit")]
  public IActionResult Edit(int dishId)
  {
    Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    if(dish is null)
    {
      return RedirectToAction("Index", "Home");
    }
    return View("editDish", dish);
  }

  [HttpPost("/dish/{dishId}/update")]
  public IActionResult Update(Dish updatedDish, int dishId)
  {
    if (!ModelState.IsValid)
    {
      Console.WriteLine("validations failed :( ");
      return Edit(dishId);
    }

    Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    if (dish is null)
    {
      return RedirectToAction("Index", "Home");
    }

    dish.Chef = updatedDish.Chef;
    dish.Name = updatedDish.Name;
    dish.Tastiness = updatedDish.Tastiness;
    dish.Calories = updatedDish.Calories;
    dish.Description = updatedDish.Description;
    dish.UpdatedAt = DateTime.Now;

    _context.Dishes.Update(dish);
    _context.SaveChanges();

    return RedirectToAction("ViewDish", new { dishId = dishId });
  }


  //* DELETE
  [HttpGet("/dish/{dishId}/delete")]
  public IActionResult Delete(int dishId)
  {
    Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == dishId);
    if (dish != null)
    {
      _context.Dishes.Remove(dish);
      _context.SaveChanges();
    }

    return RedirectToAction("Index", "Home");
  }
}