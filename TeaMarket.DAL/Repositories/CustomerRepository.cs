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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TeaMarketContext _teaMarketContext;

        public CustomerRepository(TeaMarketContext teaMarketContext)
        {
            _teaMarketContext = teaMarketContext;
        }

        public Guid Create(Customer customer)
        {
            _teaMarketContext.Customers.Add(customer);
            _teaMarketContext.SaveChanges();
            return customer.Id;
        }

        public Task<Customer> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _teaMarketContext.SaveChangesAsync();
        }

        public void Update(Customer item)
        {
            _teaMarketContext.Entry(item).State = EntityState.Modified;
        }
    }
}
