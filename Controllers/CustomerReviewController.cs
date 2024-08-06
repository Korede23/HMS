//using HMS.Dto.RequestModel;
//using HMS.Implementation.Interface;
//using Microsoft.AspNetCore.Mvc;

//namespace HMS.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomerReviewController : ControllerBase
//    {
//        private readonly ICustomerReviewService _customerReviewService;

//        public CustomerReviewController(ICustomerReviewService customerReviewService)
//        {
//            _customerReviewService = customerReviewService;
//        }

//        [HttpPost("create-review")]
//        public async Task<IActionResult> CreateReview(CreateReview request, int Id)
//        {
//            var review = await _customerReviewService.CreateReview(request, Id);
//            if (review.Success == false)
//            {
//                return Ok(review);
//            }
//            else
//            {
//                return BadRequest(review);
//            }

//        }
       
//        [HttpGet("get-all-review-created")]
//        public async Task<IActionResult> GetAllReviewAsync()
//        {
//            var review = await _customerReviewService.GetAllReviewAsync();
//            if (review.Success == false)
//            {
//                return Ok(review);
//            }
//            else
//            {
//                return BadRequest(review);
//            }


//        }

//    }
//}
