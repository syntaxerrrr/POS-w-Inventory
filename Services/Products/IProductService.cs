using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;

namespace POSniLeinard.Services.Products
{
    public interface IProductService
    {
        Task<ApiResponseMessage<string>> InsertProduct(ProductDto dto);

        Task<ApiResponseMessage<string>> UpdateProduct(ProductDto dto);
        Task<ApiResponseMessage<List<GetAllProductsDto>>> GetAllProducts();
        Task<ApiResponseMessage<GetAllProductsDto>> GetProductById(long ID);
        Task<ApiResponseMessage<string>> DeleteProductById(long ID);
    }
}