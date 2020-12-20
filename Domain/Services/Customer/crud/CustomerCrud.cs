using DataAccess.Repositories;
using DataAccess.Entities;
using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer.crud
{
    public class CustomerCrud : ICustomerCrud
    {
        private static CustomerCrud instance = null;
        private CustomerCrud() { }
        public static CustomerCrud Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerCrud();
                }

                return instance;
            }
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

        public bool RegisterCustomer(CustomerModel customer)
        {

            CustomerRepository customerRepo = new CustomerRepository();
            DataAccess.Entities.Customer theCustomer = new DataAccess.Entities.Customer()
            {
                dni = customer.dni,
                name = customer.name,
                lastname = customer.lastname,
                email = customer.email,
                password = "123"
            };
            return customerRepo.RegisterCustomer(theCustomer);

        }

        public bool UpdateCustomer(int id, CustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
