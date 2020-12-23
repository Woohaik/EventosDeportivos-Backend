using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void DeleteById(int id);
        void UpdateById(int id, T entity);
        Task Add(T entity);
    }
}
