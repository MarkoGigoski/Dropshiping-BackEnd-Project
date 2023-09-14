using Dropshiping.BackEnd.Dtos.UserDtos;
using Dropshiping.BackEnd.Services.UserServices.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Dropshiping.BackEnd.Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Creating new User
        [HttpPost("Register")]
        public IActionResult Register([FromBody]RegisterUserDto registerUserDto)
        {
            try
            {
                _userService.RegisterUser(registerUserDto);
                return Ok();
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }

        // Login with existing User
        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginUsedDto loginUsedDto)
        {
            try
            {
                var token = _userService.LoginUser(loginUsedDto);
                return Ok(token);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error happend");
            }
        }
    }
}
