using FluentValidation;
using UserManagement.APIGateway.DTOs.AuthenticationDtos;

namespace UserManagement.APIGateway.Validators.UserValidators
{
    public class UserLoginDtoValidate:AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidate()
        {
            RuleFor(u => u.UserIdentifier)
            .NotEmpty().WithMessage("UserIdentifier is required");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
