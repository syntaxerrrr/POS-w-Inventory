using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Model
{
    public class Tbl_Product
    {
        [Key]
        public long Product_Id { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Qty { get; set; }


    }
}
