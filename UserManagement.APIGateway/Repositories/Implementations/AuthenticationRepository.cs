using Microsoft.EntityFrameworkCore;
using UserManagement.APIGateway.Data;
using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.Repositories.Interfaces;

namespace UserManagement.APIGateway.Repositories.Implementations
{
    public class AuthenticationRepository(UserManagementDbContext context) : IAuthenticationRepository
    {
        public async Task<User> LoginAsync(string userIdentifier)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == userIdentifier || u.Email == userIdentifier || u.Contact == userIdentifier);
            if (user is  null)
            {
                return null;
            }
            return user;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var data = await context.Users.SingleOrDefaultAsync(u => u.UserName == user.UserName || u.Email == user.Email || u.Contact == user.Contact);
            if (data == null)
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return user;
            }
            return null;
        }
    }
}
