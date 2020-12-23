using Data.Repositories;
using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer.auth
{
    public class CustomerAuth : JWT, IAuthService
    {
        
        protected ICustomerRepository customerRepository = CustomerRepository.Instance;

        public ICustomer AuthenticateCustomer(string token)
        {
            bool istokenValid = this.ValidateToken(token);
            if (istokenValid)
            {
                ICustomer model = new CustomerModel()
                {
                    id = 5,
                    dni = "d",
                    email = "themail@gmail.com",
                    lastname = "thelast",
                    name = "Wiii"

                };
                return model;
            }
            else
            {
                return null;
            }
        }

        public IAuthentication LoginCustomer(ICredential credentials)
        {
            ICustomer model = new CustomerModel()
            {
                id = 5,
                dni = "d",
                email = "themail@gmail.com",
                lastname = "thelast",
                name = "Wiii"
            };
            IAuthentication authModel = new AuthenticationModel();
            authModel.token = this.GenerateToken(model);
            authModel.customer = model;
            return authModel;
        }
    }


}
