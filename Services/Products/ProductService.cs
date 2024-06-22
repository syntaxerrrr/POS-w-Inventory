using Microsoft.EntityFrameworkCore;
using POSniLeinard.Apiresponse;
using POSniLeinard.Dtos;
using POSniLeinard.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly POSDbContext _context;

        public ProductService(POSDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseMessage<string>> InsertProduct(ProductDto dto)
        {
            try
            {
                var _sales = new Tbl_Product
                {
                    Qty = dto.Qty,
                    Cost = dto.Cost,
                    Name = dto.Name,
                    Product_Id = dto.Product_Id

                };
                _context.Tbl_Products.Add(_sales);
                await _context.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved",
                    IsSuccess = true,
                    ErrorMessage = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                var result = new ApiResponseMessage<string>
                {
                    Data = "Error",
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };

                return result;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateProduct(ProductDto dto)
        {
            try
            {
                var _sales = await _context.Tbl_Products.FindAsync(dto.Product_Id);

                _sales.Qty = dto.Qty;
                _sales.Cost = dto.Cost;

                _context.Tbl_Products.Update(_sales);
                await _context.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "successfully Updated",
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return res;
            }
            catch (Exception ex)
            {
                {
                    var result = new ApiResponseMessage<string>
                    {
                        Data = "Error",
                        IsSuccess = false,
                        ErrorMessage = ex.Message
                    };
                    return result;
                };
            }
        }

        public async Task<ApiResponseMessage<List<GetAllProductsDto>>> GetAllProducts()
        {
            try
            {
                var _data = await _context.Tbl_Products.ToListAsync();
                var _list = new List<GetAllProductsDto>();
                {
                    foreach (var item in _data)
                    {
                        var res = new GetAllProductsDto
                        {
                            Name = item.Name,
                            Cost = item.Cost,
                            Qty = item.Qty,
                        };
                        _list.Add(res);
                    }
                    //var res = new GetAllProductsDto
                    //{
                    //    Name = _data.Name,
                    //    Cost = _data.Cost,
                    //    Qty = _data.Qty,
                    //};
                    var result = new ApiResponseMessage<List<GetAllProductsDto>>
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
                {
                    var results = new ApiResponseMessage<List<GetAllProductsDto>>
                    {
                        Data = { },
                        IsSuccess = false,
                        ErrorMessage = ex.Message
                    };
                    return results;
                }
            }
        }
        public async Task<ApiResponseMessage<GetAllProductsDto>> GetProductById(long ID)
        {
            try
            {


                var _data = await _context.Tbl_Products.Where(x => x.Product_Id == ID).FirstOrDefaultAsync();
                var res = new GetAllProductsDto
                {
                    Name = _data.Name,
                    Cost = _data.Cost,
                    Qty = _data.Qty
                };
                var result = new ApiResponseMessage<GetAllProductsDto>()
                {
                    Data = res,
                    IsSuccess = true,
                    ErrorMessage = ""
                };
                return result;
            }
            catch (Exception ex)
            {
                {
                    var results = new ApiResponseMessage<GetAllProductsDto>()
                    {
                        Data = { },
                        IsSuccess = false,
                        ErrorMessage = ex.Message
                    };
                    return results;
                }
            }
        }

        public async Task<ApiResponseMessage<string>> DeleteProductById(long ID)
        {
            try
            {

          
            var _products = await _context.Tbl_Products.Where(x => x.Product_Id == ID).FirstOrDefaultAsync();

            _context.Tbl_Products.Remove(_products!);
            await _context.SaveChangesAsync();

            var result = new ApiResponseMessage<string>
            {
                Data = "Successfully Deleted",
                IsSuccess = true,
                ErrorMessage = ""
            };
            return result;
            }
            catch ( Exception ex )
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

