using UserManagement.APIGateway.DTOs.UserDtos;
using FluentValidation;
namespace UserManagement.APIGateway.Validators.UserValidators
{
    public class UserUpdateDtoValidate : AbstractValidator<UpdateUserDto>
    {
        public UserUpdateDtoValidate()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(u => u.Id)
         .NotEmpty().WithMessage("Id is required")
         .Must(guid => guid != Guid.Empty).WithMessage("Inavlid Id.");
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("FirstName is required")
                .MaximumLength(50).WithMessage("FirstName cannot be more than 50 characterters.")
                .Matches("^[a-zA-Z]+$").WithMessage("FirstName can only contains alphabets");
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("LastName is required")
                .MaximumLength(50).WithMessage("LastName can not be more than 50 characters")
                .Matches("^[a-zA-Z]+$").WithMessage("LastName can only contains alphabets");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is Invalid.");
            RuleFor(u => u.Contact)
                .NotEmpty().WithMessage("Contact is required")
                .Matches("^[0-9]+$").WithMessage("Contact must be in digits only")
                .Length(11).WithMessage("Contact must be 11 characters long");
            RuleFor(u => u.UserName)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9_]+$").WithMessage("UserName can only contain Alphabets, digits and Underscore(_).")
                .MinimumLength(5).WithMessage("UserName cannot be less than 5 characters.")
                .MaximumLength(10).WithMessage("UserName cannot be more than 10 characters.");
            RuleFor(u => u.Address)
                .NotEmpty();
            RuleFor(u => u.City)
                .NotEmpty();
            RuleFor(u => u.Country)
                .NotEmpty();
            RuleFor(u => u.Image)
                .NotEmpty();
        }
    }
}
