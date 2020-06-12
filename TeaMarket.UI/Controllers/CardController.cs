using Stripe;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.ViewModels.Card;
using TeaMarket.BLL.ViewModels.Order;

namespace TeaMarket.UI.Controllers
{
    public class CardController : Controller
    {
        private readonly IPaymentService _paymentService;
        public CardController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public ActionResult Create(CreateCardViewModel createCard)
        {
            return View(createCard);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostPaymentViewModel paymentModel)
        {
            var wasSuccess = await _paymentService.ConfirmPay(paymentModel);
            if (wasSuccess)
            {
                return View("ThankYou");
            }
            return View("Error");
        }
    }
}