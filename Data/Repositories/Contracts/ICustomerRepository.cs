using Data.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICustomerRepository : IRepository<customers>
    {
        Task<customers> GetByEmail(string email);
        Task<customers> GetByDni(string dni);
        Task<string> GetRefreshToken(int id);
    }
}
