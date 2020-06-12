using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.DAL.Entities;

namespace TeaMarket.DAL.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Guid Create(Order order);

        void Update(Order order);

    }
}
