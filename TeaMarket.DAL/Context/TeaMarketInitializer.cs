using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.DAL.Entities;

namespace TeaMarket.DAL.Context
{
    public class TeaMarketInitializer : DropCreateDatabaseIfModelChanges<TeaMarketContext>
    {
        protected override void Seed(TeaMarketContext teaMarketContext)
        {
            var products = new List<Product>();
            var rnd = new Random();
            var productsCount = 50;
            for (int i = 0; i < productsCount; i++)
            {

                var teaColor = i % 2 == 0 ? "Black" : "Green";
                products.Add(
                    new Product {
                        Cost = rnd.Next(1, 500),
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                        Name = $"Classical { teaColor } tea #{i}",
                        Quantity = rnd.Next(1, 500)});
            }
            products.ForEach(product => teaMarketContext.Products.Add(product));
            teaMarketContext.SaveChanges();
        }

    }
}
