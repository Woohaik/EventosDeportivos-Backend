using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.services.customer.auth
{
    public interface IJWTProvider
    {

        string GenerateToken(CustomerModel model);
        bool ValidateToken(string token);
    }
}
