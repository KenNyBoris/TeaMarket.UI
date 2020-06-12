using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaMarket.BLL.ViewModels
{
    public class MakeOrderProductViewModel
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public decimal Cost { get; set; }
    }
}