using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Dtos
{
    public class CustomerDto
    {
        public long Customer_Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Phone_number { get; set; }
    }
}
