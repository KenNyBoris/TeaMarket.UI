using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.DAL.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public bool IsDeleted { get; set; }
    }
}
