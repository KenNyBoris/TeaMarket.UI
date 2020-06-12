using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.BLL.ViewModels
{
    public class GetProductDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Cost { get; set; }

        public int Quantity { get; set; }
    }
}
