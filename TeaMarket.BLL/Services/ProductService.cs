using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.ViewModels;
using TeaMarket.DAL.Entities;
using TeaMarket.DAL.Interfaces;

namespace TeaMarket.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, GetAllProductsViewModel>();
                cfg.CreateMap<Product, GetProductDetailsViewModel>();
            });

            _mapper = config.CreateMapper();
        }
        public List<GetAllProductsViewModel> GetAll()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<List<Product>, List<GetAllProductsViewModel>>(products);
        }

        public async Task<GetProductDetailsViewModel> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.FindByIdAsync(id);
            return _mapper.Map<Product, GetProductDetailsViewModel>(product);
        }

        public GetPaginatedProductsViewModel GetPaginated(int size = 25, int startFrom = 0)
        {
            var paginatedProductList = new GetPaginatedProductsViewModel();
            var products = _productRepository.GetAll();
            var filteredProducts = products.GetRange(startFrom, size);
            paginatedProductList.Products = _mapper.Map<List<Product>, List<GetAllProductsViewModel>>(filteredProducts);
            return paginatedProductList;
        }
    }
}
