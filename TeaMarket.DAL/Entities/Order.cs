using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TeaMarket.DAL.Enums;

namespace TeaMarket.DAL.Entities
{
    public class Order : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid CustomerId { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public PayMethod PayMethod { get; set; }

        public Status Status { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
