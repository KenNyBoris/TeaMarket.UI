using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.DAL.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public List<Order> Orders { get; set; }
    }
}
