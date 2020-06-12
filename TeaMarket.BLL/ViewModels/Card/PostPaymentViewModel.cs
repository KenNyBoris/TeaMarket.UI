using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.BLL.ViewModels.Card
{
    public class PostPaymentViewModel
    {
        public string OrderId { get; set; }

        public decimal OrderTotalCost { get; set; }

        public string StripeToken { get; set; }

        public string Description { get; set; }
    }
}
