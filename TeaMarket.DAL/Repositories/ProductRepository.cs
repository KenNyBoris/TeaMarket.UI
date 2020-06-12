using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.DAL.Context;
using TeaMarket.DAL.Entities;
using TeaMarket.DAL.Interfaces;

namespace TeaMarket.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly TeaMarketContext _teaMarketContext;
        public ProductRepository(TeaMarketContext teaMarketContext)
        {
            _teaMarketContext = teaMarketContext;
        }

        public async Task<Product> FindByIdAsync(Guid id)
        {
            return await _teaMarketContext.Products.FindAsync(id);
        }

        public List<Product> GetAll()
        {
            return _teaMarketContext.Products.ToList();
        }
        public async Task SaveAsync()
        {
            await _teaMarketContext.SaveChangesAsync();
        }

        public void Update(Product item)
        {
            _teaMarketContext.Entry(item).State = EntityState.Modified;
        }
    }
}
