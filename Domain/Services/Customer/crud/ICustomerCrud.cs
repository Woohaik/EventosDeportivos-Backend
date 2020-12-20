using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer.crud
{
    public interface ICustomerCrud
    {
        bool RegisterCustomer(CustomerModel customer);
        bool DeleteCustomer(int id);
        bool UpdateCustomer(int id , CustomerModel customer);
        IEnumerable<CustomerModel> GetCustomers();
        CustomerModel GetCustomerById(int id);
    }
}
