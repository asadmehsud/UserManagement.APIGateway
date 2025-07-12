using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.DTOs.AuthenticationDtos;

namespace UserManagement.APIGateway.Extensions.Mappers.AuthenticationMapper
{
    public static class UserRegisterDtoToUserMapper
    {
        public static User Map(this UserRegisterDto userRegisterDto)
        {
            return new User
            {
                Id=Guid.NewGuid(),
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                Contact= userRegisterDto.Contact,
            };
        }
    }
}
