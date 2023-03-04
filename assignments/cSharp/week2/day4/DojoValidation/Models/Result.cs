#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoValidation.Models;

public class Result
{ 
  [Required(ErrorMessage = "Name is required.")]
  [MinLength(2 , ErrorMessage = "Name must be at least 2 characters")]
  public string Name { get; set; }

  [Required(ErrorMessage = "Location is required.")]
  public string Location { get; set; }

  [Required(ErrorMessage = "Favorite Language is required.")]
  public string Language { get; set; }

  [MinLength(8, ErrorMessage = "Comments must be at least 20 characters")]
  public string? Comment { get; set; }
}