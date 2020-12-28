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
        Task<IAuthentication> GetAuthenticatedCustomer(int id);
        Task<IWholeAuth> LoginCustomer(ICredential credentials);
        Task<IWholeAuth> RefreshToken(int id , string oldToken);
        string validateToken(string token);
    }
}
