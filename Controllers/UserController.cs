using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
       

        public UserController(IUserServices  userService)
        {
            _userServices = userService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(CreateUser request)
        {
            
         var user = await   _userServices.CreateUser(request);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }

        [HttpPost("edit-user")]
        public async Task<IActionResult> EditUser([FromBody] UpdateUser request)
        {
           var user = await _userServices.UpdateUser(request.Id, request);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }


        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _userServices.DeleteUserAsync(id);
            if (user.Success == false)
            {
                return BadRequest(user) ;
            }
            return Ok(user);
        }


        [HttpGet("get-all-user-created")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userServices.GetAllUserAsync();
            if (users.Success == false)
            {
                return BadRequest(users);
            }
            return Ok(users);

        }



        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if (user.Success == false)
            {
                return BadRequest(user);
            }
            return Ok(user);
        }



    }
}
