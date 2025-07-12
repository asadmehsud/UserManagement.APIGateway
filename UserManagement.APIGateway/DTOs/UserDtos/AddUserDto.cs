namespace UserManagement.APIGateway.DTOs.UserDtos
{
    public record AddUserDto(string FirstName, string LastName, string Email, string UserName, string Contact, string Address, string City, string Country, string Image);
}
