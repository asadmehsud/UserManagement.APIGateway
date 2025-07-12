using UserManagement.APIGateway.DTOs.AuthenticationDtos;
using UserManagement.APIGateway.DTOs.UserDtos;
using UserManagement.APIGateway.Response;

namespace UserManagement.APIGateway.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<APIResponse<string>> UserLoginAsync(UserLoginDto userLoginDto);
        Task<APIResponse<GetUserDto>> UserRegistrationAsync(UserRegisterDto userRegisterDto);
    }
}
