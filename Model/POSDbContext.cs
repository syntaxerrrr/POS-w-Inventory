using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSniLeinard.Model
{
    public partial class POSDbContext : DbContext
    {

        public POSDbContext(DbContextOptions<POSDbContext> options)
            : base(options) 
        {
        }
        public virtual DbSet<Tbl_Customer> Tbl_Costumers { get; set; }
        public virtual DbSet<Tbl_Product> Tbl_Products { get; set; }
        public virtual DbSet<Tbl_SaleDetails> Tbl_SaleDetails { get; set; }
        public virtual DbSet<Tbl_User> Tbl_Users { get; set; }
        public virtual DbSet<Tbl_SalesHeader> Tbl_SalesHeaders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Defaultcon");
            }
        }
    }
}
