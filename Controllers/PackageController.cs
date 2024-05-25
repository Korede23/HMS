using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageServices _packageServices;

        public PackageController(IPackageServices packageServices)
        {
            _packageServices = packageServices;
        }

        [HttpPost("create-package")]
        public async Task<IActionResult> CreatePackage(CreatePackage request)
        {
            var item = await _packageServices.CreatePackage(request);
            if (item.Success == true)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item.Success == false);

            }

        }

        [HttpPost("edit-package")]
        public async Task<IActionResult> EditPackage([FromBody] UpdatePackage request)
        {

            var item = await _packageServices.UpdatePackage(request.Id, request);
            if (item.Success == true)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item.Success == false);

            }
        }

        [HttpDelete("delete-package")]
        public async Task<IActionResult> DeletePackageAsync([FromRoute] int id)
        {
            var item = await _packageServices.DeletePackageAsync(id);
            if (item.Success == true)
            {
                return Ok(item);
            }
            return BadRequest(item.Success == false);
        }
        [HttpGet("get-all-package-created")]
        public async Task<IActionResult> GetAllPackageAsync()
        {
            var item = await _packageServices.GetAllPackagesAsync();
            if (item.Success == true)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item.Success == false);
            }


        }

        [HttpGet("get-order-by-id/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {

            var item = await _packageServices.GetAllPackagesByIdAsync(id);
            if (item.Success == true)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item.Success == false);
            }

        }

    }
}
