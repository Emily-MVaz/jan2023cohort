#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models;
public class Dish
{
  [Key]
  public int DishId { get; set; }

  //* NAME --------------------------------------------
  [Required]
  public string Name { get; set; }

  //* CHEF --------------------------------------------
  [Required]
  public string Chef { get; set; }

  //* TASTE --------------------------------------------
  [Required]
  [Range(1, 5)]
  public int Tastiness { get; set; }

  //* CALORIES --------------------------------------------
  [Required]
  [Range(0, Int32.MaxValue, ErrorMessage = "Calories must be greater than 0")]
  public int Calories { get; set; }

  //* DESC --------------------------------------------
  [Required]
  public string Description { get; set; }

//* TIMES --------------------------------------------
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}