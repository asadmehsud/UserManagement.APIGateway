using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace UserManagement.APIGateway.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] emailIndex = value!.ToString()!.Split('@');
            if (string.IsNullOrWhiteSpace(value!.ToString()))
            {
                return new ValidationResult("Email is required.");
            }
            else if (!value.ToString()!.Contains('@'))
            {
                return new ValidationResult("Email is not Valid. Email must follow the format example@gmail.com");
            }
            else if (!Regex.IsMatch(emailIndex[0], "^(?!.)[a-zA-Z_+.0-9]$"))
            {
                return new ValidationResult("The part before @ is InValid.It must not start with dot.");
            }
            else if (!Regex.IsMatch(emailIndex[1], "^(?![.-])[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$"))
            {
                return new ValidationResult("The part after @ is Invalid. It must not start with any special character like hyphen(-) or Dot(.) etc or TLD(.com) length must at lest two alphabets.");
            }
            else if (value.ToString()!.Contains(".."))
            {
                return new ValidationResult("Email must not contain consective dots(.).");
            }
            return ValidationResult.Success;
        }
    }
}
