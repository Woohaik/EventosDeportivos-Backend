using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.ICustomerContracts;

namespace Domain.Models.Customer
{
    public class CustomerModel : ICustomer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string dni { get; set; }
    }
}
