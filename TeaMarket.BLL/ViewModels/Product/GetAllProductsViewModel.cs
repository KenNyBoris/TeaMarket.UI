using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.BLL.ViewModels
{
    public class GetAllProductsViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }
    }
}
