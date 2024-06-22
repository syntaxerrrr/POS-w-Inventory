using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Dtos
{
    public class HeaderDto
    {
        public long Sales_Id { get; set; }
        public long Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public long Customer_Id { get; set; }
        public string? Customer_Name { get; set; }
        public string? Transaction_Name { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedStamp { get; set; }
    }
}
