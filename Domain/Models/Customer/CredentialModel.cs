using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Customer
{
    public class CredentialModel : ICredential
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
