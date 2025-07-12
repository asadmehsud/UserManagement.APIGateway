namespace UserManagement.APIGateway.DTOs.UserDtos
{
    public record GetUserDto(Guid Id, string FirstName, string LastName, string UserName, string Email, string Contact, string Address, string City, string Country, string Image);
}
