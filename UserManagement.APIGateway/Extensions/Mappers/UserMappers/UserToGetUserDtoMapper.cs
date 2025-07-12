using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.DTOs.UserDtos;

namespace UserManagement.APIGateway.Extensions.Mappers.UserMappers
{
    public static class UserToGetUserDtoMapper
    {
        public static GetUserDto Map(this User user)
        {
            return new GetUserDto(user.Id, user.FirstName, user.LastName, user.UserName, user.Email, user.Contact, user.Address, user.City, user.Contact, user.Image);
        }
    }
}
