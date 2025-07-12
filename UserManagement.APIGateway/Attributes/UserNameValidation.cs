using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserManagement.APIGateway.Attributes
{
    // I have craeted this custome validation for stopping to show all the validation messages simultaneously.
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class UserNameValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(value!.ToString()))
            {
                return new ValidationResult("UserName is Required.");
            }
            else if (!Regex.IsMatch(value.ToString()!, "^[a-zA-Z0-9_]+$"))
            {
                return new ValidationResult("Invalid UserName. Must contain alphabets,digits or underscore(_).");
            }
            else if (value.ToString()!.Length < 5)
            {
                return new ValidationResult("UserName length must be at least 5.");
            }
            else if (value.ToString()!.Length > 10)
            {
                return new ValidationResult("UserName length must not exceed 10.");
            }
            return ValidationResult.Success;
        }
    }
}
