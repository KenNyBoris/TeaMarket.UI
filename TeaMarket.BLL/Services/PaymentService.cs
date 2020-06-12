using Stripe;
using Stripe.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.ViewModels.Card;
using TeaMarket.DAL.Enums;
using TeaMarket.DAL.Interfaces;

namespace TeaMarket.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public PaymentService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<bool> ConfirmPay(PostPaymentViewModel payInfo)
        {
            //TODO need to use using
            try
            {
                var order = await _orderRepository.FindByIdAsync(Guid.Parse(payInfo.OrderId));
                order.Status = Status.Paid;
                _orderRepository.Update(order);
                var product = await _productRepository.FindByIdAsync(order.ProductId);
                product.Quantity -= order.Quantity;
                _productRepository.Update(product);
                var options = new ChargeCreateOptions
                {
                    Amount = (long)payInfo.OrderTotalCost * 100,
                    Currency = "usd",
                    Description = payInfo.Description,
                    Source = payInfo.StripeToken
                };

                var service = new ChargeService();
                Charge charge = service.Create(options);
                await _orderRepository.SaveAsync();
                await _productRepository.SaveAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
