using Domain.models;
using Domain.services.customer.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.services.customer
{
    public class CustomerService : ICustomerService
    {
        private static CustomerService instance;

        private CustomerService() { }

        public static CustomerService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerService();
                }

                return instance;
            }
        }


        public CustomerModel AuthenticateCustomer(string token)
        {
            return Auth.Instance.Authenticate(token);
        }

        public bool deleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel getCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public AuthenticationModel LoginCustomer(CredentialModel credentials)
        {
            return Auth.Instance.Login(credentials);
        }

        public bool RegisterCustomer(CustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public CustomerModel updateCustomer(int id, CustomerModel customer)
        {
            throw new NotImplementedException();
        }

    }
}
