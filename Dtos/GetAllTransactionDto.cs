using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Dtos
{
    public class GetAllTransactionDto
    {
        public long Id { get; set; }
        public long Customer_Id { get; set; }

        public string? Customer_name { get; set; }
      
        public string? Product_name { get; set; }
        public string? Transaction_name { get; set; }

        public decimal Cost { get; set; }
        public decimal TotalCost { get; set; }
    }
}
