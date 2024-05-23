using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole(CreateRole request)
        {
          var role = await  _roleService.CreateRole(request);
            if (role.Success == true)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(role.Success == false);
            }
        }

        [HttpPost("edit-role")]
        public async Task<IActionResult> EditRole([FromBody] UpdateRole request)
         {

           var role = await _roleService.UpdateRole(request.Id,request);
            if (role.Success == true)
            {
              return Ok(role);  
            }
            else
            {
                return BadRequest(role.Success == false);
            }
        }

        [HttpDelete("delete-role/{id}")]
        public  async Task<IActionResult> DeleteRole([FromRoute] int id)
        {
            var role =await _roleService.DeleteRole(id);
            if (role.Success == true)
            {
                return Ok(role);
            }
            else
            {
                return BadRequest(role.Success == false);
            }
        }
        [HttpGet("get-all-role-created")]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var roles =await _roleService.GetAllRolesAsync();
            if (roles.Success == true)
            {
                return Ok(roles);  
            }
            else
            {
                return BadRequest(roles.Success == false);
            }

        }

        [HttpGet("get-role-by-id/{id}")]
        public async Task<IActionResult> GetRoleByIdAsync(int id)
        {
            var roles = await _roleService.GetRoleByIdAsync(id);
            if (roles.Success == true)
            {
                return Ok(roles);
            }
            else
            {
                return BadRequest(roles.Success == false);  
            }

        }


    }
}

