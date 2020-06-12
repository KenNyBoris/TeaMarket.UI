using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.BLL.ViewModels.Card
{
    public class CreateCardViewModel
    {
        public string OrderId { get; set; }

        public string CustomerName { get; set; }

        public decimal OrderTotalCost { get; set; }

        public string Description { get; set; }
    }
}
