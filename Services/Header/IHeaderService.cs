using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;

namespace POSniLeinard.Services.Header
{
    public interface IHeaderService
    {
        Task<ApiResponseMessage<string>> InsertTransaction(HeaderDto dto);

        Task<ApiResponseMessage<List<GetAllTransactionDto>>> GetAllTransaction();
        Task<ApiResponseMessage<GetAllTransactionDto>> GetTransactionById(long Customer_Id);
        Task<ApiResponseMessage<GetAllTransactionDto>> UpdateTransaction(GetAllTransactionDto dto);
        Task<ApiResponseMessage<string>> DeleteTransaction(long transactionId);
    }
}