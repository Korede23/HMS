using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using HMS.Model.Entity.Enum;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class CustomerReviewService : ICustomerReviewService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICustomerServices _customerServices;

        public CustomerReviewService(ApplicationDbContext dbContext, ICustomerServices customerServices)
        {
            _dbContext = dbContext;
            _customerServices = customerServices;
        }

        public async Task<BaseResponse> CreateReview(CreateReview request, int Id)
        {
            var customer = await _customerServices.GetCustomerByIdAsync(Id);
            if (customer == null)
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "User Not Found",
                    Hasherror = true
                };
            }
            var review = new CustomerReview
            {
                // CustomerId = request.Id,
                Comment = request.Comment,


            };
            _dbContext.CustomerReviews.Add(review);
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Succesfully Commented on Review"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Comment Failed"
                };
            }

        }








        //public async Task<ReviewResponseDto> GetAllReviewAsync()
        //{
        //    var review = await _dbContext.CustomerReviews
        //       // .Where(x => x.)
        //       .Select(x => new CustomerReviewDto
        //       {

        //           Comment = x.Comment

        //       }).ToListAsync();

        //    if (review != null)
        //    {
        //        return new ReviewResponseDto
        //        {
        //            Success = true,
        //            Message = "Review Retrieved Succesfully",
        //            Data = review
        //        };
        //    }
        //    else
        //    {
        //        return new ReviewResponseDto
        //        {
        //            Success = false,
        //            Message = "failed",
        //            Hasherror = true
        //        };
        //    }
        //}



        public async Task<ReviewResponseDto> GetAllReviewAsync()
        {



            var review = await _dbContext.CustomerReviews
               .Where(x => (int)x.Rating == (int)Review.Excellent ||
                    (int)x.Rating == (int)Review.Good ||
                    (int)x.Rating == (int)Review.Bad)
                .Select(x => new CustomerReviewDto
                {
                   
                    Comment = x.Comment,
                })
                .ToListAsync();

            if (review != null )
            {
                return new ReviewResponseDto
                {
                    Success = true,
                    Message = "Review Retrieved Successfully",
                    Data = review
                };
            }
            else
            {
                return new ReviewResponseDto
                {
                    Success = false,
                    Message = "Failed to retrieve reviews",
                    Hasherror = true
                };
            }
        }
    }

}

