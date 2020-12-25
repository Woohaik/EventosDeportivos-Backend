using Data.Repositories;
using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt;
using Data;

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
            customers dbCustomer = this.customerRepository.GetByEmail(credentials.email);
            if (dbCustomer == null) throw new Exception("Usuario no encontrado");
            ICustomer model = new CustomerModel()
            {
                id = dbCustomer.customerid,
                dni = dbCustomer.customerdni,
                email = dbCustomer.customeremail,
                lastname = dbCustomer.customerlastname,
                name = dbCustomer.customername,
            };
            if (!this.validatePassword(credentials.password, dbCustomer.customerpassword)) throw new Exception("Contraseña Incorrecta");
            return new AuthenticationModel()
            {
                customer = model,
                token = this.GenerateToken(model)
            };
        }

        private string getRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

        protected string hashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, getRandomSalt());
        }

        protected bool validatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }
    }


}
