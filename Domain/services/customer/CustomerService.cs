﻿using Domain.Models.Customer;
using Domain.Services.Customer.auth;
using Domain.Services.Customer.crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private static CustomerService instance;
        private Auth authService = Auth.Instance;
        private CustomerCrud crudService = CustomerCrud.Instance;

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
            return authService.AuthenticateCustomer(token);
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public AuthenticationModel LoginCustomer(CredentialModel credentials)
        {
            return authService.LoginCustomer(credentials);
        }

        public bool RegisterCustomer(CustomerModel customer)
        {
            return crudService.RegisterCustomer(customer);
        }

        public bool UpdateCustomer(int id, CustomerModel customer)
        {
            throw new NotImplementedException();
        }

    }
}
