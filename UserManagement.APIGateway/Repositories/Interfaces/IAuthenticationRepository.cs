using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.DTOs.UserDtos;

namespace UserManagement.APIGateway.Repositories.Interfaces
{
    public interface IAuthenticationRepository
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string userIdentifier);
    }
}
