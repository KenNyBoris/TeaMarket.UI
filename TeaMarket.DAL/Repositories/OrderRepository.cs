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
    public class OrderRepository : IOrderRepository
    {
        private readonly TeaMarketContext _teaMarketContext;

        public OrderRepository(TeaMarketContext teaMarketContext)
        {
            _teaMarketContext = teaMarketContext;
        }

        public Guid Create(Order order)
        {
            _teaMarketContext.Orders.Add(order);
            _teaMarketContext.SaveChanges();
            return order.Id;
        }

        public async Task<Order> FindByIdAsync(Guid id)
        {
            return await _teaMarketContext.Orders.FindAsync(id);
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _teaMarketContext.SaveChangesAsync();
        }

        public void Update(Order item)
        {
            _teaMarketContext.Entry(item).State = EntityState.Modified;
        }
    }
}
