using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TeaMarket.BLL.Enums;
using TeaMarket.DAL.Enums;

namespace TeaMarket.BLL.ViewModels.Order
{
    public class CreateOrderViewModel
    {
        public CreateOrderViewModel()
        {
            Customer = new CreateOrderCustomerModelViewModel();
            Product = new CreateOrderProductModelViewModel();
            DeliveryMethods = new List<SelectListItem>();
            PayMethods = new List<SelectListItem>();
        }
        public List<SelectListItem> DeliveryMethods { set; get; }

        public DeliveryMethodViewModel SelectedDeliveryMethod { get; set; }

        public PayMethodViewModel SelectedPayMethod { get; set; }

        public List<SelectListItem> PayMethods { set; get; }
        public int Quantity { get; set; }

        public CreateOrderCustomerModelViewModel Customer { get; set; }

        [NotMapped]
        public CreateOrderProductModelViewModel Product { get; set; }
    }

    public class CreateOrderCustomerModelViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        [Required]
        public string Address { get; set; }
    }

    public class CreateOrderProductModelViewModel
    {
        public string Id { get; set; }

        public decimal Cost { get; set; }
    }

}
