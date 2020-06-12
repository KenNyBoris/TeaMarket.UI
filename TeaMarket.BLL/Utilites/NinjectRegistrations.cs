using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.DAL.Interfaces;
using TeaMarket.DAL.Repositories;

namespace TeaMarket.BLL.Utilites
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
        }

    }
}
