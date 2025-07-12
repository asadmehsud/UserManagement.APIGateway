namespace UserManagement.APIGateway.DTOs.AuthenticationDtos
{
    public record UserRegisterDto
    (
        string UserName,
        string Email,
        string Contact,
        string Password,
        string ConfirmPassword
    );
}
