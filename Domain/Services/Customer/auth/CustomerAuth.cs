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
using Domain.Services.Customer.crud;

namespace Domain.Services.Customer.auth
{
    public class CustomerAuth : CustomerCrud, IAuthService
    {

        private JWT jwt = new JWT();

        public async Task<IAuthentication> GetAuthenticatedCustomer(int id)
        {

            // Buscar por el cliente En bbdd
            ICustomer customer = await this.GetById(id);

            IAuthentication theAuth = new AuthenticationModel()
            {
                customer = customer,
                token = jwt.GenerateToken(customer, false),
            };

            return theAuth;
        }

        public IWholeAuth LoginCustomer(ICredential credentials)
        {
            customers dbCustomer = this.customerRepository.GetByEmail(credentials.email);
            ICustomer model = new CustomerModel()
            {
                id = dbCustomer.customerid,
                dni = dbCustomer.customerdni,
                email = dbCustomer.customeremail,
                lastname = dbCustomer.customerlastname,
                name = dbCustomer.customername,
            };
            if (!this.validatePassword(credentials.password, dbCustomer.customerpassword)) throw new Exception("Contraseña Incorrecta");

            string refreshToken = this.jwt.GenerateToken(model, true);

            // Guardar Token en BBDD


            return new AuthenticationModel()
            {
                customer = model,
                token = jwt.GenerateToken(model, false),
                refreshToken = refreshToken
            };
        }

        protected bool validatePassword(string password, string correctHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, correctHash);
        }

        public string validateToken(string token)
        {
            if (this.jwt.ValidateToken(token))
            {
                return this.jwt.decodeToken(token);
            }
            else
            {
                return null;
            }

        }
    }


}
