using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.IServicesContracts
{
    public interface IAuthService
    {
        Task<IAuthentication> GetAuthenticatedCustomer(int token);
        IWholeAuth LoginCustomer(ICredential credentials);
        string validateToken(string token);
    }
}
