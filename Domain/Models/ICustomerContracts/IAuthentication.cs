using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ICustomerContracts
{
    public interface IAuthentication
    {

        string token { get; set; }
        ICustomer customer { get; set; }
    }
}
