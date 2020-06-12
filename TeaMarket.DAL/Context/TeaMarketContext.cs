using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.DAL.Entities;

namespace TeaMarket.DAL.Context
{
    public class TeaMarketContext : DbContext
    {
        public TeaMarketContext() : base("TeaMarket")
        {
            Database.SetInitializer(new TeaMarketInitializer());
        }


        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
