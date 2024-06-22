using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;
using POSniLeinard.Services.Header;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IHeaderService _headerService;

        public TransactionController(IHeaderService HeaderService)
        {
            _headerService = HeaderService;
        }

        [HttpPost("InsertTransaction")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertTransaction(HeaderDto dto)
        {
            var res = await _headerService.InsertTransaction(dto);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {

            }
        }

        [HttpGet("GetAllTransaction")]
        public async Task<ActionResult<ApiResponseMessage<List<GetAllTransactionDto>>>> GetAllTransaction()
        {
            var res = await _headerService.GetAllTransaction();
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {

            }
        }
        [HttpGet("GetTransactionById/ID")]
        public async Task<ActionResult<ApiResponseMessage<GetAllTransactionDto>>> GetTransactionById(long Customer_Id)
        {
            var res = await _headerService.GetTransactionById(Customer_Id);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {

            }
        }
        [HttpPost("UpdateTransaction")]
        public async Task<ActionResult<ApiResponseMessage<GetAllTransactionDto>>> UpdateTransaction(GetAllTransactionDto dto)
        {
            var res = await _headerService.UpdateTransaction(dto);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {

            }
        }
        [HttpDelete("DeleteTransaction")]
        public async Task<ActionResult<ApiResponseMessage<string>>> DeleteTransaction(long transactionId)
        {
            var res = await _headerService.DeleteTransaction(transactionId);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {

            }
        }
    }
}
