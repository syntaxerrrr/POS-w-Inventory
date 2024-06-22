using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;
using POSniLeinard.Services.Products;

namespace PointOfSale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("InsertProduct")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertProduct(ProductDto dto)
        {
            var res = await _productService.InsertProduct(dto);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
            {
                
            }
        }

        [HttpPost("UpdateProduct")]
        public async Task<ActionResult<ApiResponseMessage<string>>> UpdateProduct(ProductDto dto)
        {
            var res = await _productService.UpdateProduct(dto);
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ApiResponseMessage<List<GetAllProductsDto>>>> GetAllProducts()
        {
            var res = await _productService.GetAllProducts();
            if (res != null)
            {
                return res;
            }
            return NotFound("No Data Found");
        }

        [HttpGet("GetProductsById/ID")]
        public async Task<ActionResult<ApiResponseMessage<GetAllProductsDto>>> GetProductsById(long ID)
        {
            var res = await _productService.GetProductById(ID);
            if (res != null)
            {
                return res;
            }
            return NotFound("No Data Found");
            {
                
            }
        }

        [HttpDelete("DeleteById")]
        public async Task<ActionResult<ApiResponseMessage<string>>> DeleteProductById(long ID)
        {
            var res = await _productService.DeleteProductById(ID);
            if(res != null)
            {
                return Ok(res);
            }
            return NotFound("No Data Found");
        }
    }
}
