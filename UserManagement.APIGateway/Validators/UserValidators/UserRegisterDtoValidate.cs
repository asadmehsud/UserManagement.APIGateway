using FluentValidation;
using UserManagement.APIGateway.DTOs.AuthenticationDtos;

namespace UserManagement.APIGateway.Validators.UserValidators
{
    public class UserRegisterDtoValidate : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidate()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(u => u.UserName)
            .NotEmpty()
            .Matches("^[a-zA-Z0-9_]+$")
            .MinimumLength(5)
            .MaximumLength(10);
            RuleFor(u => u.Contact)
                .NotEmpty()
                .Matches("^[0-9]+$")
                .Length(11);
            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(u => u.Password)
                .NotEmpty();
            RuleFor(u => u.ConfirmPassword)
                .NotEmpty()
                .Equal(u => u.Password).WithMessage("Pleasee Re-Confirm your password");
        }
    }
}
