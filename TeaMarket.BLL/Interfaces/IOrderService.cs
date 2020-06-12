using System;
using System.Threading.Tasks;
using TeaMarket.BLL.ViewModels.Order;

namespace TeaMarket.BLL.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CreateAsync(CreateOrderViewModel order);
        Task ConfirmPayment(string orderId);
    }
}
