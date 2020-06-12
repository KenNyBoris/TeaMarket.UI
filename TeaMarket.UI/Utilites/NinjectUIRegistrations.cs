using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.Services;

namespace TeaMarket.UI.Utilites
{
    public class NinjectUIRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IPaymentService>().To<PaymentService>();
        }
    }
}