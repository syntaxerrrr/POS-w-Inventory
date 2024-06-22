using Microsoft.EntityFrameworkCore;
using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;
using POSniLeinard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Services.Header
{
    public class HeaderService : IHeaderService
    {
        private readonly POSDbContext _context;

        public HeaderService(POSDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseMessage<string>> InsertTransaction(HeaderDto dto)
        {
            try
            {

                var customer = await _context.Tbl_Costumers.FirstOrDefaultAsync(x => (x.First_name + " " + x.Last_name) == dto.Customer_Name);

                if (customer == null)
                {
                    return new ApiResponseMessage<string>
                    {
                        Data = "Error: Customer not found",
                        IsSuccess = false,
                        ErrorMessage = "Error"
                    };
                }


                var product = await _context.Tbl_Products.FirstOrDefaultAsync(x => x.Name == dto.Product_Name);

                if (product == null)
                {
                    return new ApiResponseMessage<string>
                    {
                        Data = "Error: Product not found",
                        IsSuccess = false,
                        ErrorMessage = "Error"
                    };
                }

                if (product.Qty <= 0)
                {
                    return new ApiResponseMessage<string>
                    {
                        Data = "Error: Product out of stock",
                        IsSuccess = false,
                        ErrorMessage = "Error"
                    };
                }


                var salesHeader = new Tbl_SalesHeader
                {
                    Transaction_Name = dto.Transaction_Name,
                    Product_Name = dto.Product_Name,
                    Customer_Name = dto.Customer_Name,
                    CreatedStamp = DateTime.Now,
                    ModifiedStamp = DateTime.Now,
                    Tbl_Customers = customer,
                    Tbl_SaleDetails = new List<Tbl_SaleDetails>()
                };

                var saleDetail = new Tbl_SaleDetails
                {
                    Name = product.Name,
                    Cost = product.Cost,
                    Qty = 1,
                    CreatedStamp = DateTime.Now,
                    ModifiedStamp = DateTime.Now,
                    Tbl_Products = product
                };

                salesHeader.Tbl_SaleDetails.Add(saleDetail);


                product.Qty -= saleDetail.Qty;


                _context.Entry(product).State = EntityState.Modified;

                _context.Tbl_SalesHeaders.Add(salesHeader);
                await _context.SaveChangesAsync();

                return new ApiResponseMessage<string>
                {
                    Data = "Successfully Created",
                    IsSuccess = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseMessage<string>
                {
                    Data = "Error",
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ApiResponseMessage<List<GetAllTransactionDto>>> GetAllTransaction()
        {
            try
            {
                var _data = await _context.Tbl_SalesHeaders.Include(s => s.Tbl_SaleDetails).ToListAsync();

                if (_data == null)
                {
                    return new ApiResponseMessage<List<GetAllTransactionDto>>
                    {
                        Data = null,
                        IsSuccess = false,
                        ErrorMessage = "No transactions found"
                    };
                }

                var resultList = new List<GetAllTransactionDto>();

                foreach (var salesHeader in _data)
                {
                    foreach (var saleDetail in salesHeader.Tbl_SaleDetails)
                    {
                        var res = new GetAllTransactionDto
                        {
                            Id = salesHeader.Sales_Id,
                            Customer_name = salesHeader.Customer_Name,
                            Product_name = saleDetail.Name,
                            Transaction_name = salesHeader.Transaction_Name,
                            Cost = saleDetail.Cost
                        };
                        resultList.Add(res);
                    }
                }

                var result = new ApiResponseMessage<List<GetAllTransactionDto>>
                {
                    Data = resultList,
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return result;
            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<List<GetAllTransactionDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;
            }
        }

        public async Task<ApiResponseMessage<GetAllTransactionDto>> GetTransactionById(long Customer_Id)
        {
            try
            {
                var transactions = await _context.Tbl_SalesHeaders
                    .Where(x => x.Tbl_Customers.Customer_Id == Customer_Id)
                    .Include(x => x.Tbl_SaleDetails)
                    .ThenInclude(sd => sd.Tbl_Products)
                    .ToListAsync();

                if (transactions == null || transactions.Count == 0)
                {
                    return new ApiResponseMessage<GetAllTransactionDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        ErrorMessage = "Transactions not found for the given customer"
                    };
                }

                decimal totalCost = transactions.Sum(t => t.Tbl_SaleDetails.Sum(sd => sd.Cost));

                var transactionNames = transactions.Select(t => t.Transaction_Name).Distinct();
                var productNames = transactions
                    .SelectMany(t => t.Tbl_SaleDetails.Select(sd => sd.Tbl_Products.Name))
                    .Distinct();

                var _data = new GetAllTransactionDto
                {
                    Id = transactions[0].Sales_Id,
                    Customer_Id = Customer_Id,
                    Transaction_name = string.Join(", ", transactionNames),
                    Product_name = string.Join(", ", productNames),
                    TotalCost = totalCost
                };

                var result = new ApiResponseMessage<GetAllTransactionDto>
                {
                    Data = _data,
                    IsSuccess = true,
                    ErrorMessage = ""
                };

                return result;
            }
            catch (Exception ex)
            {
                var result = new ApiResponseMessage<GetAllTransactionDto>
                {
                    Data = null,
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };

                return result;
            }
        }


        public async Task<ApiResponseMessage<GetAllTransactionDto>> UpdateTransaction(GetAllTransactionDto dto)
        {
            try
            {
                // Get the transaction details by customer ID
                var transactionResponse = await GetTransactionById(dto.Customer_Id);

                if (!transactionResponse.IsSuccess || transactionResponse.Data == null)
                {
                    return new ApiResponseMessage<GetAllTransactionDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        ErrorMessage = "Transaction not found"
                    };
                }

                var transactionDto = transactionResponse.Data;

                decimal newCost = transactionDto.TotalCost - dto.TotalCost;

                if (newCost < 0)
                {
                    return new ApiResponseMessage<GetAllTransactionDto>
                    {
                        Data = null,
                        IsSuccess = false,
                        ErrorMessage = "New cost cannot be negative"
                    };
                }

                transactionDto.TotalCost = newCost;

                // Check if all associated sale details have the same transaction ID
                var transactionId = transactionDto.Id;
                var transactiontheSame = await _context.Tbl_SalesHeaders.Include(x => x.Tbl_SaleDetails)
                    .FirstOrDefaultAsync(e => e.Sales_Id == transactionId);

                if (transactiontheSame == null)
                {
                    // Proceed with deletion
                    var deleteResponse = await DeleteTransaction(transactionId);
                    if (!deleteResponse.IsSuccess)
                    {
                        // Handle delete transaction failure
                        return new ApiResponseMessage<GetAllTransactionDto>
                        {
                            Data = null,
                            IsSuccess = false,
                            ErrorMessage = "Failed to delete transaction: " + deleteResponse.ErrorMessage
                        };
                    }
                }
                else
                {
                    // Remove associated sale details
                    if (transactiontheSame.Tbl_SaleDetails != null)
                    {
                        _context.Tbl_SaleDetails.RemoveRange(transactiontheSame.Tbl_SaleDetails);
                    }

                    _context.Tbl_SalesHeaders.Remove(transactiontheSame);
                    await _context.SaveChangesAsync();
                }

                var result = new ApiResponseMessage<GetAllTransactionDto>
                {
                    Data = transactionDto,
                    IsSuccess = true,
                    ErrorMessage = ""
                };

                return result;
            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<GetAllTransactionDto>
                {
                    Data = null,
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;
            }
        }






        public async Task<ApiResponseMessage<string>> DeleteTransaction(long transactionId)
        {
            try
            {
                var transaction = await _context.Tbl_SalesHeaders
                    .Include(x => x.Tbl_SaleDetails)
                    .FirstOrDefaultAsync(e => e.Sales_Id == transactionId);

                if (transaction == null)
                {
                    return new ApiResponseMessage<string>
                    {
                        Data = "",
                        IsSuccess = false,
                        ErrorMessage = "Transaction not found."
                    };
                }

                _context.Tbl_SalesHeaders.Remove(transaction);

                // Remove associated sale details
                if (transaction.Tbl_SaleDetails != null)
                {
                    _context.Tbl_SaleDetails.RemoveRange(transaction.Tbl_SaleDetails);
                }

                await _context.SaveChangesAsync();

                return new ApiResponseMessage<string>
                {
                    Data = "Transaction and associated details deleted successfully",
                    IsSuccess = true,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }
        }












    }
}
