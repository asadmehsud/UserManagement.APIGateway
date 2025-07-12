using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.DTOs.UserDtos;

namespace UserManagement.APIGateway.Extensions.Mappers.UserMappers
{
    public static class UpdateUserDtoToUserMapper
    {
        public static User Map(this UpdateUserDto updateUserDto)
        {
            return new User()
            {
                //Id = updateUserDto.Id,
                FirstName = updateUserDto.FirstName,
                LastName = updateUserDto.LastName,
                Email = updateUserDto.Email,
                UserName = updateUserDto.UserName,
                Contact = updateUserDto.Contact,
                Address = updateUserDto.Address,
                City = updateUserDto.City,
                Country = updateUserDto.Country,
                Image = updateUserDto.Image
            };
        }
    }
}
