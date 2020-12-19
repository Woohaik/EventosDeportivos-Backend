using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.services.customer
{
    public interface ICustomerService
    {
        CustomerModel AuthenticateCustomer(string token);
        AuthenticationModel LoginCustomer(CredentialModel credentials);
        bool RegisterCustomer(CustomerModel customer);
        List<CustomerModel> GetCustomers();
        CustomerModel getCustomerById(int id);
        bool deleteCustomer(int id);
        CustomerModel updateCustomer(int id, CustomerModel customer);
    }
}
