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
        bool DeleteById(int id);
        bool UpdateById(int id, T model);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
