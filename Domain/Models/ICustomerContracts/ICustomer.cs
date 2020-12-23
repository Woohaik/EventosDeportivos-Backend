using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ICustomerContracts
{
    public interface ICustomer
    {
        int id { get; set; }
        string name { get; set; }
        string lastname { get; set; }
        string email { get; set; }
        string dni { get; set; }
    }
}
