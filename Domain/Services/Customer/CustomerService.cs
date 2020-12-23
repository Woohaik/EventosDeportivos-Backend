using Domain.Models.ICustomerContracts;
using Domain.Services.Customer.crud;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer
{
    public class CustomerService : CustomerCrud, ICustomerService
    {
        private CustomerService() { }
        private static CustomerService instance = null;
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

    }
}
