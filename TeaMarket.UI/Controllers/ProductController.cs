using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.ViewModels;

namespace TeaMarket.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult Index(int? size, int? startFrom)
        {
            GetPaginatedProductsViewModel products;
            if (size != null && startFrom != null)
            {
                products = _productService.GetPaginated((int)size, (int)startFrom);
            }
            else
            {
                products = _productService.GetPaginated();
            }
            return View(products);
        }

        [HttpGet]
        public async Task<ActionResult> GetDetails(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }
    }
}