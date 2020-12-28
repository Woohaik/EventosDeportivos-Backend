using Data.Repositories;
using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Data.DBMODELS;
using Domain.Services.Customer.crud;

namespace Domain.Services.Customer.auth
{
    public class CustomerAuth : CustomerCrud, IAuthService
    {

        private JWT jwt = new JWT();

        public async Task<IAuthentication> GetAuthenticatedCustomer(int id)
        {
            ICustomer customer = await this.GetById(id);    // Buscar por el cliente En bbdd

            IAuthentication theAuth = new AuthenticationModel()
            {
                customer = customer,
                token = jwt.GenerateToken(customer, false),
            };

            return theAuth;
        }

        private string generateTokenByModel(ICustomer model, bool isRefresh)
        {
            return this.jwt.GenerateToken(model, isRefresh);
        }

        public async Task<IWholeAuth> LoginCustomer(ICredential credentials)
        {
            customers dbCustomer = this.customerRepository.GetByEmail(credentials.email);
            if (!this.validatePassword(credentials.password, dbCustomer.customerpassword)) throw new Exception("Contraseña Incorrecta");
            return await saveNewRefreshToken(dbCustomer);
        }

        protected bool validatePassword(string password, string correctHash) => BCrypt.Net.BCrypt.Verify(password, correctHash);

        public string validateToken(string token) => this.jwt.ValidateToken(token) ? this.jwt.decodeToken(token) : null;

        private async Task<AuthenticationModel> saveNewRefreshToken(customers dbCustomer)
        {
            ICustomer model = new CustomerModel()
            {
                id = dbCustomer.customerid,
                dni = dbCustomer.customerdni,
                email = dbCustomer.customeremail,
                lastname = dbCustomer.customerlastname,
                name = dbCustomer.customername,
            };
            string newRefreshToken = generateTokenByModel(model, true);
            dbCustomer.refreshtoken = newRefreshToken;
            await this.customerRepository.UpdateById(dbCustomer.customerid, dbCustomer);
            return new AuthenticationModel()
            {
                customer = model,
                token = generateTokenByModel(model, false),
                refreshToken = newRefreshToken
            };
        }

        public async Task<IWholeAuth> RefreshToken(int id, string oldToken)
        {
            customers dbCustomer = await this.customerRepository.GetById(id);    // Buscarlo en ddbb
            string dbRefreshToken = dbCustomer.refreshtoken;
            if (!dbRefreshToken.Equals(oldToken)) throw new Exception("Refresh Token No Valida");
            return await saveNewRefreshToken(dbCustomer);
        }
    }


}
