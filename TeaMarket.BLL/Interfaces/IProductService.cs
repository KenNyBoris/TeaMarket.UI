using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaMarket.BLL.ViewModels;

namespace TeaMarket.BLL.Interfaces
{
    public interface IProductService
    {
        List<GetAllProductsViewModel> GetAll();
        GetPaginatedProductsViewModel GetPaginated(int size = 25, int startFrom = 0);
        Task<GetProductDetailsViewModel> GetByIdAsync(Guid id);
    }
}
