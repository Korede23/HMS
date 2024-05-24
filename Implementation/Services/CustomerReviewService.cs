using HMS.Dto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
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
                Text = request.Text,


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


        public async Task<BaseResponse> DeleteReview(int Id)
        {
            var review = await _dbContext.CustomerReviews.FirstOrDefaultAsync(x => x.Id == Id);
            if (review != null)
            {
                _dbContext.CustomerReviews.Remove(review);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Review Has Been Deleted Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "fail to delete Review,"
                };
            }
        }


        public async Task<ReviewResponseDto> GetReviewByIdAsync(int Id)
        {
            var review = await _dbContext.CustomerReviews
                .Where(x => x.Id == Id)
                .Select(x => new CustomerReviewDto
                {
                   
                    Text = x.Text,
                }).ToListAsync();

            if (review != null)
            {
                return new ReviewResponseDto
                {
                    Success = true,
                    Message = "Review Retrieved Succesfully",
                    Data = review
                };
            }
            else
            {
                return new ReviewResponseDto
                {
                    Success = false,
                    Message = "failed",
                    Hasherror = true
                };
            }
        }


        public async Task<ReviewResponseDto> GetAllReviewAsync()
        {
            var review = await _dbContext.CustomerReviews
               .Select(x => new CustomerReviewDto
               {
                  
                   Text = x.Text,
               }).ToListAsync();

            if (review != null)
            {
                return new ReviewResponseDto
                {
                    Success = true,
                    Message = "Review Retrieved Succesfully",
                    Data = review
                };
            }
            else
            {
                return new ReviewResponseDto
                {
                    Success = false,
                    Message = "failed",
                    Hasherror = true
                };
            }
        }

        public async Task<BaseResponse> UpdateReview(int Id, UpdateReview request)
        {
            var review = await _dbContext.CustomerReviews.FirstOrDefaultAsync(x => x.Id == Id);
            if (review != null)
            {
                review.Text = request.Text;

            }
            _dbContext.CustomerReviews.Add(review);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Review Updated Succesfully",

                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Review Update Failed",
                    Hasherror = true
                };
            }
        }
    }
}
