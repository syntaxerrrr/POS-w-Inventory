using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Model
{
    public class Tbl_User
    {

        [Key]
        public long User_Id { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
    }
}