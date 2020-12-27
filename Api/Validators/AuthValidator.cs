using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Api.Validators
{
    public class AuthValidator
    {

        public void authvalidator(HttpRequestHeaders header, IAuthService customerAuthServices)
        {
            if (header.Contains("sportToken"))
            {
                string customerIdfromToken = customerAuthServices.validateToken(header.GetValues("sportToken").First());
                if (customerIdfromToken == null) throw new Exception("Invalid Token");
                header.Add("CustomerId", customerIdfromToken);
            }
            else
            {
                throw new Exception("No se encontro el token");
            }
        }
    }
}