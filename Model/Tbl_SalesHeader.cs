using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Model
{
    public class Tbl_SalesHeader
    {
        [Key]
        public long Sales_Id { get; set; }

        [Required]
        public string? Transaction_Name { get; set; }
        public string? Product_Name { get; set; }
        public string? Customer_Name { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedStamp { get; set; }

        public ICollection<Tbl_SaleDetails> Tbl_SaleDetails { get; set; }
        public Tbl_Customer Tbl_Customers { get; set; }
    }
}
