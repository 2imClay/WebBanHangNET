using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyDbContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}