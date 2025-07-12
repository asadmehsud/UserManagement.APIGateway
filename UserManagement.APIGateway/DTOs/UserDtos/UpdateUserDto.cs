namespace UserManagement.APIGateway.DTOs.UserDtos
{
    public record UpdateUserDto(Guid Id, string FirstName, string LastName, string Email, string Contact, string Address, string UserName, string City, string Country, string Image);
}
