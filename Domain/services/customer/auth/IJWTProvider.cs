using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer.auth
{
    public interface IJWTProvider
    {

        string GenerateToken(CustomerModel model);
        bool ValidateToken(string token);
    }
}
