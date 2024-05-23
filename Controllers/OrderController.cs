using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderServices;

        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }



        [HttpPost("create-order")]
        public async Task<IActionResult> CreateRoom(CreateOrder request)
        {
            var order = await _orderServices.CreateOrder(request);
            if (order.Success == true)
            {
                return Ok(order);
            }
            else
            {
                return BadRequest(order.Success == false);
            }

        }

        [HttpPost("edit-order")]
        public async Task<IActionResult> EditOrder([FromBody] UpdateOrder request)
        {

            var order = await _orderServices.UpdateOrder(request.CustomerId, request);
            if (order.Success == true)
            {
                return Ok(order);
            }
            else
            {
                return BadRequest(order.Success == false);
            }
        }

        [HttpDelete("delete-order")]
        public async Task<IActionResult> DeleteRoomAsync([FromRoute] int id)
        {
            var order = await _orderServices.DeleteOrderAsync(id);
            if (order.Success == true)
            {
                return Ok(order);
            }
            return BadRequest(order.Success == false);

        }
        [HttpGet("get-all-order-created")]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            var order   = await _orderServices.GetAllOrderAsync();
            if (order.Success == true)
            {
                return Ok(order);
            }
            else
            {
                return BadRequest(order.Success == false);
            }


        }

        [HttpGet("get-order-by-id/{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {

            var order = await _orderServices.GetOrderByIdAsync(id);
            if (order.Success == true)
            {
                return Ok(order);
            }
            else
            {
                return BadRequest(order.Success == false);
            }

        }


    }
}
