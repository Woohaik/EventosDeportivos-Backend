using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.IServicesContracts
{
    public interface ICustomerService : IAuthService , ICrud<ICustomer>
    {

    }
}
