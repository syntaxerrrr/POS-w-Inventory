using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;

namespace POSniLeinard.Services.Customers
{
    public interface ICustomerService
    {
        Task<ApiResponseMessage<string>> DeleteCustomerById(long ID);
        Task<ApiResponseMessage<List<GetAllCustomersDto>>> GetAllCustomer();
        Task<ApiResponseMessage<GetAllCustomersDto>> GetCustomerById(long ID);
        Task<ApiResponseMessage<string>> InsertCustomer(CustomerDto dto);
        Task<ApiResponseMessage<string>> UpdateCustomer(CustomerDto dto);
    }
}