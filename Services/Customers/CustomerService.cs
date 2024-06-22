using Microsoft.EntityFrameworkCore;
using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;
using POSniLeinard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly POSDbContext _context;
        public CustomerService(POSDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseMessage<string>> InsertCustomer(CustomerDto dto)
        {
            try
            {
                var _costumer = new Tbl_Customer
                {
                    First_name = dto.First_name,
                    Last_name = dto.Last_name,
                    Phone_number = dto.Phone_number,
                    Customer_Id = dto.Customer_Id,
                };

                _context.Tbl_Costumers.Add(_costumer);
                await _context.SaveChangesAsync();

                var result = new ApiResponseMessage<string>
                {
                    Data = "Saved",
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return result;

            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<string>
                {
                    Data = "Error",
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateCustomer(CustomerDto dto)
        {
            try
            {
                var _costumer = await _context.Tbl_Costumers.FindAsync(dto.Customer_Id);

                _costumer.First_name = dto.First_name;
                _costumer.Last_name = dto.Last_name;
                _costumer.Phone_number = dto.Phone_number;

                _context.Tbl_Costumers.Update(_costumer);
                await _context.SaveChangesAsync();

                var result = new ApiResponseMessage<string>
                {
                    Data = "Successfully Updated",
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return result;

            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<string>
                {
                    Data = "Error",
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;

            }
        }

        public async Task<ApiResponseMessage<List<GetAllCustomersDto>>> GetAllCustomer()
        {
            try
            {
                var _costumers = await _context.Tbl_Costumers.ToListAsync();
                var _list = new List<GetAllCustomersDto>();
                {
                    foreach (var o in _costumers)
                    {
                        var res = new GetAllCustomersDto
                        {
                            First_name = o.First_name,
                           Last_name = o.Last_name,
                            Phone_number = o.Phone_number,
                        };
                        _list.Add(res);
                    }
                    var result = new ApiResponseMessage<List<GetAllCustomersDto>>
                    {
                        Data = _list,
                        IsSuccess = true,
                        ErrorMessage = ""
                    };
                    return result;
                }

            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<List<GetAllCustomersDto>>
                {
                    Data = { },
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;
            }
        }

        public async Task<ApiResponseMessage<GetAllCustomersDto>> GetCustomerById(long ID)
        {
            try
            {
                var _costumers = await _context.Tbl_Costumers.Where(x => x.Customer_Id == ID).FirstOrDefaultAsync();

                var _data = new GetAllCustomersDto
                {
                    First_name = _costumers!.First_name,
                    Last_name = _costumers!.Last_name,
                    Phone_number = _costumers.Phone_number,
                };
                var result = new ApiResponseMessage<GetAllCustomersDto>
                {
                    Data = _data,
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return result;


            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<GetAllCustomersDto>
                {
                    Data = { },
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;
            }
        }

        public async Task<ApiResponseMessage<string>> DeleteCustomerById(long ID)
        {
            try
            {
                var _data = await _context.Tbl_Costumers.Where(x => x.Customer_Id == ID).FirstOrDefaultAsync();

                _context.Tbl_Costumers.Remove(_data!);
                await _context.SaveChangesAsync();

                var result = new ApiResponseMessage<string>
                {
                    Data = "Successfully Deleted",
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return result;
            }
            catch (Exception ex)
            {
                var results = new ApiResponseMessage<string>
                {
                    Data = "Error",
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
                return results;
            }
        }
    }
}
