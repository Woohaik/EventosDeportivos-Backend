using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task DeleteById(int id);
        Task UpdateById(int id, T entity);
        Task Add(T entity);
    }
}
