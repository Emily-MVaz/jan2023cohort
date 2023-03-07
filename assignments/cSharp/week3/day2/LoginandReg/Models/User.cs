#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginandReg.Models;

public class User
{
  [Key]
  public int UserId { get; set; }

  [Display(Name = "First Name")]
  [MinLength(2, ErrorMessage = "must be at least 2 characters!")]
  [Required]
  public string FirstName { get; set; }

  [Display(Name = "Last Name")]
  [MinLength(2, ErrorMessage = "must be at least 2 characters!")]
  [Required]
  public string LastName { get; set; }

  [EmailAddress]
  [Required]
  [UniqueEmail]
  public string Email { get; set; }

  [MinLength(8, ErrorMessage = "must be at least 8 characters!")]
  [Required]
  [DataType(DataType.Password)]
  public string Password { get; set; }

  [NotMapped]
  [DataType(DataType.Password)]
  [Compare("Password")]
  [Required]
  [Display(Name = "Confirm Password")]
  public string PasswordConfirm { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
public class UniqueEmailAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value == null)
    {
      return new ValidationResult("Email is required!");
    }

    MyContext _context = (MyContext)validationContext.GetService(typeof(MyContext));
    if (_context.Users.Any(e => e.Email == value.ToString()))
    {
      return new ValidationResult("Email is already in use!");
    }
    else
    {
      return ValidationResult.Success;
    }
  }
}
