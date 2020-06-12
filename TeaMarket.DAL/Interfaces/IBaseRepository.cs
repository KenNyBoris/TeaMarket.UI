using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaMarket.DAL.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        List<T> GetAll();

        Task<T> FindByIdAsync(Guid id);

        void Update(T item);

        Task SaveAsync();
    }
}
