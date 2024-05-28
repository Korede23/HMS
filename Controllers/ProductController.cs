using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _packageServices;

        public ProductController(IProductServices packageServices)
        {
            _packageServices = packageServices;
        }

        [HttpPost("create-package")]
        public async Task<IActionResult> CreatePackage(CreateProduct request)
        {
            var item = await _packageServices.CreateProduct(request);
            if (item.Success == false)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item);

            }

        }

        [HttpPost("edit-package")]
        public async Task<IActionResult> EditPackage([FromBody] UpdateProduct request)
        {

            var item = await _packageServices.UpdateProduct(request.Id, request);
            if (item.Success == false)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item);

            }
        }

        [HttpDelete("delete-package")]
        public async Task<IActionResult> DeletePackageAsync([FromRoute] int id)
        {
            var item = await _packageServices.DeleteProductAsync(id);
            if (item.Success == false)
            {
                return Ok(item);
            }
            return BadRequest(item);
        }
        [HttpGet("get-all-package-created")]
        public async Task<IActionResult> GetAllPackageAsync()
        {
            var item = await _packageServices.GetAllProductAsync();
            if (item.Success == false)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item);
            }


        }

        [HttpGet("get-order-by-id/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {

            var item = await _packageServices.GetAllProductsByIdAsync(id);
            if (item.Success == false)
            {
                return Ok(item);
            }
            else
            {
                return BadRequest(item);
            }

        }

    }
}
