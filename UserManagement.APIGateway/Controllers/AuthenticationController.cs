using Microsoft.AspNetCore.Mvc;
using UserManagement.APIGateway.DTOs.AuthenticationDtos;
using UserManagement.APIGateway.Services.Interfaces;

namespace UserManagement.APIGateway.Controllers
{
    /// <summary>
    /// Handles user authentication-related operations such as registration and login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)] // Indicates a successful operation
    [ProducesResponseType(StatusCodes.Status400BadRequest)] // Indicates a client-side error (invalid request)
    [ProducesResponseType(StatusCodes.Status500InternalServerError)] // Indicates a server-side error
    public class AuthenticationController(IAuthenticationService authenticationService,ILogger<AuthenticationController> logger) : ControllerBase
    {
        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="userRegisterDto">User registration details.</param>
        /// <returns>
        /// - 200 OK: If registration is successful.
        /// - 409 Conflict: If registration fails (e.g., user already exists).
        /// </returns>
        [ProducesResponseType(StatusCodes.Status409Conflict)] // Indicates conflict (e.g., user already exists)
        [HttpPost("/api/register")]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var response = await authenticationService.UserRegistrationAsync(userRegisterDto);
            return response.Data is null ? Conflict(response) : Ok(response);
        }

        /// <summary>
        /// Authenticates a user and generates an access token.
        /// </summary>
        /// <param name="userLoginDto">User login credentials.</param>
        /// <returns>
        /// - 200 OK: If login is successful and returns authentication details.
        /// - 404 Not Found: If user credentials are incorrect or user does not exist.
        /// </returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Indicates user not found
        [HttpPost("/api/login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            logger.LogInformation("Verifying user...");
            var response = await authenticationService.UserLoginAsync(userLoginDto);
            return response.Data is null ? NotFound(response) : Ok(response);
        }
    }
}

