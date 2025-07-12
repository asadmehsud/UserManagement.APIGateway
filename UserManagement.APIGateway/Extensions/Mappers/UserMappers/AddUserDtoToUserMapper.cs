using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.DTOs.UserDtos;

namespace UserManagement.APIGateway.Extensions.Mappers.UserMappers
{
    public static class AddUserDtoToUserMapper
    {
        public static User Map(this AddUserDto addUserDto)
        {
            return new User
            {
                FirstName = addUserDto.FirstName,
                LastName = addUserDto.LastName,
                Email = addUserDto.Email,
                Contact = addUserDto.Contact,
                UserName = addUserDto.UserName,
                Address = addUserDto.Address,
                City = addUserDto.City,
                Country = addUserDto.Country,
                Image = addUserDto.Image,
            };
        }
    }
}
