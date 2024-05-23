using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using HMS.Implementation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingServices _bookService;

        public BookingController(IBookingServices bookService)
        {  
            _bookService = bookService;
        }
        [HttpPost("create-booking")]
        public async Task<IActionResult> CreateBooking(CreateBooking request)
        {
          var booking = await  _bookService.CreateBooking(request);
            if (booking.Success == true)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest(booking.Success == false);
            }
        }

        [HttpPost("edit-Booking")]
        public async Task<IActionResult> EditBooking([FromBody] UpdateBooking request)
        {

           var booking = await _bookService.UpdateBooking(request.Id, request);
            if (booking.Success == true)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest(booking.Success == false);
            }
        }

        [HttpDelete("delete-booking/{id}")]
        public async Task<IActionResult> DeleteBooking([FromRoute] int id)
        {
            var booking = await _bookService.DeleteBooking(id);
            if (booking.Success == true)
            {
                return Ok(booking);
            }
            else
            {
                return BadRequest(booking.Success == false);
            }
        }
        [HttpGet("get-all-booking-created")]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            var bookings = await _bookService.GetAllBookingsAsync();
            if (bookings.Success == true)
            {
                return Ok(bookings);
            }
            else
            {
                return BadRequest(bookings.Success == false);
            }


        }

        [HttpGet("get-booking-by-id/{id}")]
        public async Task<IActionResult> GetBookingByIdAsync(int id)
        {
            var bookings = await _bookService.GetBookingByIdAsync(id);
            if (bookings.Success == true)
            {
                return Ok(bookings);
            }
            else
            {
                return BadRequest(bookings.Success == false);
            }
        }


    }
}
