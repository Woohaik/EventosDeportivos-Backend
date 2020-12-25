using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICustomerRepository : IRepository<customers>
    {
        customers GetByEmail(string email);
    }
}
