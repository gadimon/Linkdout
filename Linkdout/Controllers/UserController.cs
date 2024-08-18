using Linkdout.DTO;
using Linkdout.Moodels;
using Linkdout.Services;
using Microsoft.AspNetCore.Mvc;

namespace Linkdout.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;
        public UserController(UserService _userService) 
        { 
            userService = _userService; 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SingleUserResponseDTO>> getUser(int id)
        {
            UserModel user = await userService.GetUserById(id);
            return user != null ? Ok(user) : NotFound();

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> register([FromBody] UserModel user)
        {
            int userId = await userService.Register(user);
            if (userId != 0)
            {
                await Response.WriteAsync(userId.ToString());
                return Created();
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
