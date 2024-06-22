using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Dtos
{
    public class ProductDto
    {
        public long Product_Id { get; set; }
        public string? Name { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Qty { get; set; }
    }
}
