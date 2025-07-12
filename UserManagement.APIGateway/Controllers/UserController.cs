using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagement.APIGateway.DTOs.UserDtos;

namespace UserManagement.APIGateway.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("/api/GetUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok("All users");
        }
        [HttpPut]
        [Route("/api/Update")]
        public IActionResult UpdateUser(UpdateUserDto updateUserDto)
        {
            return Ok("Updated successfully");
        }
    }
}
