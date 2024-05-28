using HMS.Dto.RequestModel;
using HMS.Implementation.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerServices customerServices) : Controller
    {
        private readonly ICustomerServices _customerServices = customerServices;

        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomer(CreateCustomer request)
        {

            var customer = await _customerServices.CreateCustomer(request);
            if (customer.Success == false)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest(customer);
            }

        }

        [HttpPost("edit-customer")]
        public async Task<IActionResult> EditCustomer([FromBody] UpdateCustomer request)
        {
            var customer = await _customerServices.UpdateCustomer(request.Id, request);
            if (customer.Success == false)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest(customer);
            }

        }


        [HttpDelete("delete-customer/{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _customerServices.DeleteCustomerAsync(id);
            if (customer.Success == false)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest(customer);
            }

        }


        [HttpGet("get-all-user-customer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customer = await _customerServices.GetAllCustomerCreatedAsync();
            if (customer.Success == false)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest(customer);
            }

        }



        [HttpGet("get-customer-by-id/{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerServices.GetCustomerByIdAsync(id);
            if (customer.Success == false)
            {
                return Ok(customer);
            }
            else
            {
                return BadRequest(customer);
            }
        }


    }
}


