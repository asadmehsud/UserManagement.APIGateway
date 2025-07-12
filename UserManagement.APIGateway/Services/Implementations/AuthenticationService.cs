using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.DTOs.AuthenticationDtos;
using UserManagement.APIGateway.DTOs.UserDtos;
using UserManagement.APIGateway.Extensions.Mappers.AuthenticationMapper;
using UserManagement.APIGateway.Extensions.Mappers.UserMappers;
using UserManagement.APIGateway.Repositories.Interfaces;
using UserManagement.APIGateway.Response;
using UserManagement.APIGateway.Services.Interfaces;

namespace UserManagement.APIGateway.Services.Implementations
{
    public class AuthenticationService(IAuthenticationRepository authenticationRepository, IConfiguration configuration) : IAuthenticationService
    {
        public async Task<APIResponse<string>> UserLoginAsync(UserLoginDto userLoginDto)
        {
            var user = await authenticationRepository.LoginAsync(userLoginDto.UserIdentifier);
            if (user is null)
            {
                return APIResponse<string>.ErrorResponse("User not exist.");
            }
            else if (!VerifyPasswordHashandSalt(userLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return APIResponse<string>.ErrorResponse("User is not exist.");
            }
            return APIResponse<string>.SuccessResponse(CreateToken(user));
        }
        public async Task<APIResponse<GetUserDto>> UserRegistrationAsync(UserRegisterDto userRegisterDto)
        {
            var user = userRegisterDto.Map();
            CreatePasswordHashandSalt(userRegisterDto.Password, out byte[] passwordhash, out byte[] passwordsalt);
            user.PasswordHash = passwordhash;
            user.PasswordSalt = passwordsalt;
            return await authenticationRepository.RegisterAsync(user) is null ? APIResponse<GetUserDto>.ErrorResponse("This user is already exist") :
                                                                               APIResponse<GetUserDto>.SuccessResponse(user.Map());
        }
        private void CreatePasswordHashandSalt(string password, out byte[] passwordhash, out byte[] passwordsalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordsalt = hmac.Key;
            passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        private bool VerifyPasswordHashandSalt(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual(passwordHash);
        }
        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
            new(ClaimTypes.Role,user.Role.ToString())
            };
            var tokenKey = configuration.GetSection("Token").Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Audience = configuration["Audience"],
                Issuer = configuration["Issuer"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
