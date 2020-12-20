using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Customer.auth
{
    public class Auth : IAuth
    {


        private static Auth instance = null;



        private Auth()
        {


        }

        public static Auth Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Auth();
                }

                return instance;
            }
        }



        private bool validateCredentials()
        {
            return true;
        }

        public AuthenticationModel LoginCustomer(CredentialModel credentials)
        {
            CustomerModel model = new CustomerModel()
            {
                id = 5,
                dni = "d",
                email = "themail@gmail.com",
                lastname = "thelast",
                name = "Wiii"

            };


            AuthenticationModel authModel = new AuthenticationModel();
            authModel.token = JWTProvider.Instance.GenerateToken(model);
            authModel.customerModel = model;

            return authModel;
        }

        public CustomerModel AuthenticateCustomer(string token)
        {
            bool istokenValid = JWTProvider.Instance.ValidateToken(token);

            if (istokenValid)
            {
                CustomerModel model = new CustomerModel()
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
    }
}
