using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityService _amenityService;

        public AmenityController(IAmenityService amenityService)
        {
           _amenityService = amenityService;
        }

        [HttpPost("create-amenity")]
        public async Task<IActionResult> CreateAmenity(CreateAmenityRequestModel request, int Id)
        {
            var amenity = await _amenityService.CreateAmenity(request);
            if (amenity.Success == false)
            {
                return Ok(amenity);
            }
            else
            {
                return BadRequest(amenity);
            }
        }

        [HttpPut("edit-amenity")] 
        public async Task<IActionResult> EditAmenity([FromBody] UpdateAmenity request)
        {

            var amenity = await _amenityService.UpdateAmenity( request.Id , request);
            if (amenity.Success == false)
            {
                return Ok(amenity);
            }
            else
            {
                return BadRequest(amenity);
            }
        }

        [HttpDelete("delete-amenity/{id}")]
        public async Task<IActionResult> DeleteAmenity([FromRoute] int id)
        {
            var amenity = await _amenityService.DeleteAmenity(id);
            if (amenity.Success == false)
            {
                return Ok(amenity);
            }
            else
            {
                return BadRequest(amenity);
            }
        }
        [HttpGet("get-all-amenity-created")]
        public async Task<IActionResult> GetAllAmenity()
        {
            var amenity = await _amenityService.GetAllAmenity();
            if (amenity.Success == false)
            {
                return Ok(amenity);
            }
            else
            {
                return BadRequest(amenity);
            }


        }

        [HttpGet("get-amenity-by-id/{id}")]
        public async Task<IActionResult> GetAmenityById(int id)
        {
            var amenity = await _amenityService.GetAmenityById(id);
            if (amenity.Success == false)
            {
                return Ok(amenity);
            }
            else
            {
                return BadRequest(amenity);
            }
        }

    }
}
