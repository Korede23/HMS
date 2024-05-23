using HMS.Dto.BookingDto;
using HMS.Dto.RequestModel;
using HMS.Dto.ResponseModel;
using HMS.Implementation.Interface;
using HMS.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Implementation.Services
{
    public class BookingService : IBookingServices
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<BaseResponse> CreateBooking(CreateBooking request)
        {
            if (request != null)
            {

                var existingBooking = _dbContext.Bookings.FirstOrDefault(x =>
                   x.CheckIn == request.CheckIn &&
                   x.Checkout == request.Checkout &&
                   x.Duration == request.Duration &&
                   x.Status == request.Status);

                if (existingBooking != null)
                {
                    // Booking already exists
                    return new BaseResponse
                    {
                        Success = true,
                        Message = $"Booking already exists.",
                        Hasherror = true
                    };

                }

                var booking = new Booking()
                {
                    CheckIn = request.CheckIn,
                    Duration = request.Duration,
                    Checkout = request.Checkout,
                    Status = request.Status,
                    TotalCost = request.TotalCost,
                };
                _dbContext.Bookings.Add(booking);
            

                if (await _dbContext.SaveChangesAsync() > 0)
                {
                    return new BaseResponse
                    {
                        Success = true,
                        Message = $"Your booking  has been successful"
                    };
                }
                else
                {
                    return new BaseResponse
                    {
                        Success = false,
                        Message = "Booking Failed, unable to complete your booking request.",
                        Hasherror = true
                    };
                }
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = "Booking Failed, unable to complete your booking request.",
                    Hasherror = true
                };
            }
        }

      

        public async Task<BaseResponse> DeleteBooking(int Id)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(x => x.Id == Id);
            if (booking != null)
            {
                _dbContext.Bookings.Remove(booking);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Booking {Id} Has been Deleted Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Delete Failed unable to process the deletion of  booking {Id} at this time",
                    Hasherror = true
                };
            }
        }


        public async Task<BookingResponseDto> GetBookingByIdAsync(int Id)
        {
           var bookings = await _dbContext.Bookings
            .Where(x => x.Id == Id)
            .Select(x => new BookingDto()
            {
                Duration = x.Duration,
                CheckIn = x.CheckIn,
                Checkout = x.Checkout,
                Status = x.Status,
                TotalCost = x.TotalCost,
              //  Id = x.RoomId,
            }).ToListAsync();
            if (bookings != null)
            {
                return new BookingResponseDto
                {
                    Success = true,
                    Message = "Bookings Retrieved Succesfully",
                    Data = bookings
                };
            }
            else
            {
                return new BookingResponseDto
                {
                    Success = false,
                    Message = "Booking Retrieved Failed",
                    Hasherror = true
                };
            }
        }
        

        public async Task<BookingResponseDto> GetAllBookingsAsync()
        {
            var booking = await _dbContext.Bookings
            .Select(x => new BookingDto()
            {
                Duration = x.Duration,
                CheckIn = x.CheckIn,
                Checkout = x.Checkout,
                Status = x.Status,
                TotalCost = x.TotalCost,
               // RoomId = x.RoomId,
            }).ToListAsync();
            if (booking != null)
            {
                return new BookingResponseDto
                {
                    Success = true,
                    Message = "Bookings Retrieved Succesfully",
                    Data = booking
                };
            }
            else
            {
                return new BookingResponseDto
                {
                    Success = false,
                    Message = "Bookings Retrieval Failed",
                    Data = booking,
                    Hasherror =true
                };
            }
        }

        public async Task<BaseResponse> UpdateBooking(int Id, UpdateBooking request)
        {
            var booking = _dbContext.Bookings.FirstOrDefault(x => x.Id == Id);
            if (booking != null)
            {
                booking.Duration = request.Duration;
                booking.CheckIn = request.CheckIn;
                booking.Checkout = request.Checkout;
                booking.RoomId = request.RoomId;
                booking.Status = request.Status;
                booking.TotalCost = request.TotalCost;
            }
            _dbContext.Bookings.Update(booking);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = $"Booking {Id} Updated Succesfully"
                };
            }
            else
            {
                return new BaseResponse
                {
                    Success = false,
                    Message = $"Booking {Id} Update Failed",
                    Hasherror = false
                };
            }
        }


    }
}
