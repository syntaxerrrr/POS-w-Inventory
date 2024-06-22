using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;
using POSniLeinard.Services.Customers;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("InsertCustomer")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCustomer(CustomerDto dto)
        {
            var res = await _customerService.InsertCustomer(dto);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {

            }
        }
        [HttpPost("UpdateCustomer")]
        public async Task<ActionResult<ApiResponseMessage<string>>> UpdateCustomer(CustomerDto dto)
        {
            var res = await _customerService.UpdateCustomer(dto);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
        }

        [HttpGet("GetAllCustomers")]
        public async Task<ActionResult<ApiResponseMessage<List<GetAllCustomersDto>>>> GetAlCustomer()
        {
            var res = await _customerService.GetAllCustomer();
            if (res != null)
            {
                return res;
            }
            return NotFound("No Data Found");
        }

        [HttpGet("GetAllCustomers/ID")]
        public async Task<ActionResult<ApiResponseMessage<GetAllCustomersDto>>> GetCustomerById(long ID)
        {
            var res = await _customerService.GetCustomerById(ID);
            if (res != null)
            {
                return res;
            }
            return NotFound("No Data Found");
            {

            }
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<ApiResponseMessage<string>>> DeleteCustomerById(long ID)
        {
            var res = await _customerService.DeleteCustomerById(ID);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
        }
    }
}

