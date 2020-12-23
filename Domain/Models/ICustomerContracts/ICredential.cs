using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ICustomerContracts
{
    public interface ICredential
    {
        string email { get; set; }
        string password { get; set; }
    }
}
