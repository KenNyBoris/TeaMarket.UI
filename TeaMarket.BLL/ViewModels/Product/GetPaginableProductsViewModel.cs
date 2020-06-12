using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.BLL.ViewModels
{
    public class GetPaginatedProductsViewModel
    {
        public GetPaginatedProductsViewModel()
        {
            this.Size = 10;
            this.StartFrom =  0;
            this.Products = new List<GetAllProductsViewModel>();
        }

        public int Size { get; set; }

        public int StartFrom { get; set; }

        public List<GetAllProductsViewModel> Products { set; get; }
    }
}
