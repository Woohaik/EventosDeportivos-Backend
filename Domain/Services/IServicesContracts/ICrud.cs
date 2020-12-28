using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICrud<T>
    {
        Task Add(T model);
        Task DeleteById(int id);
        Task UpdateById(int id, T model);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
