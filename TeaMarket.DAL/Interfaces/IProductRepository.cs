using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.DAL.Entities;

namespace TeaMarket.DAL.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
