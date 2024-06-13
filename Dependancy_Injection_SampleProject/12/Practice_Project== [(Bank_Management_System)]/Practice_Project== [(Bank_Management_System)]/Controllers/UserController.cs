using Microsoft.AspNetCore.Mvc;
using Practice_Project_____Bank_Management_System__.DTO;
using Practice_Project_____Bank_Management_System__.Interfaces;

namespace Practice_Project_____Bank_Management_System__.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser(UserDTO userDTO)
        {
            var response = await _userService.AddUser(userDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> GetUserByUId(string UId)
        {
            var response = await _userService.GetUserByUId(UId);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult> UpdateUserByID(string userId, [FromBody] UserDTO userDto)
        {
            var result = await _userService.ReplaceAsync(userId, userDto);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
