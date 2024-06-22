using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Model
{
    public class Tbl_SaleDetails
    {
        [Key]
        public long Sales_Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Qty { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedStamp { get; set; }

        public Tbl_Product Tbl_Products { get; set; }
        
    }

}
