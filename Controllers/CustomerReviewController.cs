using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerReviewController : ControllerBase
    {
        private readonly ICustomerReviewService _customerReviewService;

        public CustomerReviewController(ICustomerReviewService customerReviewService)
        {
            _customerReviewService = customerReviewService;
        }

        [HttpPost("create-review")]
        public async Task<IActionResult> CreateReview(CreateReview request, int Id)
        {
            var review = await _customerReviewService.CreateReview(request, Id);
            if (review.Success == true)
            {
                return Ok(review);
            }
            else
            {
                return BadRequest(review.Success == false);
            }

        }

        [HttpPost("edit-review")]
        public async Task<IActionResult> EditReview([FromBody] UpdateReview request)
        {

            var order = await _customerReviewService.UpdateReview(request.Id, request);
            if (order.Success == true)
            {
                return Ok(order);
            }
            else
            {
                return BadRequest(order.Success == false);
            }
        }

        [HttpDelete("delete-review")]
        public async Task<IActionResult> DeleteReviewAsync([FromRoute] int id)
        {
            var review = await _customerReviewService.DeleteReview(id);
            if (review.Success == true)
            {
                return Ok(review);
            }
            return BadRequest(review.Success == false);

        }
        [HttpGet("get-all-review-created")]
        public async Task<IActionResult> GetAllReviewAsync()
        {
            var review = await _customerReviewService.GetAllReviewAsync();
            if (review.Success == true)
            {
                return Ok(review);
            }
            else
            {
                return BadRequest(review.Success == false);
            }


        }

        [HttpGet("get-review-by-id/{id}")]
        public async Task<IActionResult> GetReviewByIdAsync(int id)
        {

            var review = await _customerReviewService.GetReviewByIdAsync(id);
            if (review.Success == true)
            {
                return Ok(review);
            }
            else
            {
                return BadRequest(review.Success == false);
            }

        }

    }
}
