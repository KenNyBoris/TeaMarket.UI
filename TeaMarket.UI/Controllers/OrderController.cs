using Stripe;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using TeaMarket.BLL.Enums;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.ViewModels;
using TeaMarket.BLL.ViewModels.Card;
using TeaMarket.BLL.ViewModels.Order;

namespace TeaMarket.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult MakeOrder(MakeOrderProductViewModel productToOrder)
        {
            var orderModel = new CreateOrderViewModel();
            orderModel.Quantity = productToOrder.Quantity;
            InitializeDropdownItemsForOrder(orderModel);
            orderModel.Product.Id = productToOrder.Id;
            orderModel.Product.Cost = productToOrder.Cost;
            return View(orderModel);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmOrder(CreateOrderViewModel order)
        {
            var orderId = await _orderService.CreateAsync(order);
            if (order.SelectedPayMethod == PayMethodViewModel.CreditCard)
            {
                return RedirectToAction("Create",
                    "Card",
                    new CreateCardViewModel 
                    { 
                        CustomerName = order.Customer.Name,
                        OrderId = orderId.ToString(),
                        OrderTotalCost = order.Product.Cost * order.Quantity 
                    });
            }
            return View("AreYouShure",orderId);
        }

        [HttpPost]
        public async Task<ActionResult> ConfirmPayment(string orderId)
        {
            await _orderService.ConfirmPayment(orderId);
            return View("ThankYou");
        }

        private void InitializeDropdownItemsForOrder(CreateOrderViewModel order)
        {
            var payMethods = Enum.GetValues(typeof(PayMethodViewModel)).Cast<PayMethodViewModel>().ToList();
            payMethods.ForEach(s => order.PayMethods.Add(new SelectListItem { Text = s.ToString(), Value = s.ToString() }));

            var deliveryMethods = Enum.GetValues(typeof(DeliveryMethodViewModel)).Cast<DeliveryMethodViewModel>().ToList();
            deliveryMethods.ForEach(s => order.DeliveryMethods.Add(new SelectListItem { Text = s.ToString(), Value = s.ToString() }));
        }
    }
}