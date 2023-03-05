#pragma warning disable CS8618 
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;


public class Date
{
  [FutureDate]
  public DateTime date_time { get; set; }
}
public class FutureDateAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    TimeSpan diff = DateTime.Now - (DateTime)value;
    if (diff < TimeSpan.Zero)
    {
      return new ValidationResult("Date must be earlier than the current date");
    }
    return ValidationResult.Success;
  }
}

