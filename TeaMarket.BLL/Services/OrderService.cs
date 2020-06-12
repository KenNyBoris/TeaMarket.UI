using AutoMapper;
using System;
using System.Threading.Tasks;
using TeaMarket.BLL.Interfaces;
using TeaMarket.BLL.ViewModels.Order;
using TeaMarket.DAL.Entities;
using TeaMarket.DAL.Interfaces;

namespace TeaMarket.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CreateOrderViewModel, Order>()
                .ForMember(s => s.PayMethod, opt => opt.MapFrom(w => w.SelectedPayMethod))
                .ForMember(s => s.DeliveryMethod, opt => opt.MapFrom(w => w.SelectedDeliveryMethod))
                .ForMember(s => s.Product, opt => opt.Ignore())
                .ForMember(s => s.ProductId, opt => opt.MapFrom(w => w.Product.Id));
                cfg.CreateMap<CreateOrderCustomerModelViewModel, Customer>();
            });

            _mapper = config.CreateMapper();
        }

        public async Task ConfirmPayment(string orderId)
        {
            var order = await _orderRepository.FindByIdAsync(Guid.Parse(orderId));
            order.Status = DAL.Enums.Status.Paid;
            var product = await _productRepository.FindByIdAsync(order.ProductId);
            product.Quantity -= order.Quantity;
            _orderRepository.Update(order);
            _productRepository.Update(product);
            await _orderRepository.SaveAsync();
            await _productRepository.SaveAsync();
        }

        public async Task<Guid> CreateAsync(CreateOrderViewModel orderModel)
        {
            var order = new Order();
            var customer = new Customer();
            var product = await _productRepository.FindByIdAsync(Guid.Parse(orderModel.Product.Id));
            customer = _mapper.Map<CreateOrderCustomerModelViewModel, Customer>(orderModel.Customer);
            _customerRepository.Create(customer);
            order = _mapper.Map<CreateOrderViewModel, Order>(orderModel);
            order.Status = DAL.Enums.Status.Prepared;
            order.TotalCost = product.Cost * orderModel.Quantity;
            return _orderRepository.Create(order);
        }
    }
}
