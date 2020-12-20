using Domain.Services.Customer;
using Domain.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Services.Customer.auth;

namespace Api.Controllers
{

    public class AuthController : ApiController
    {
        private IAuth customerAuthservices = CustomerService.Instance;

        [HttpPost]
        [Route("api/auth/login")]
        public HttpResponseMessage Login([FromBody] CredentialModel userCred)
        {
            return Request.CreateResponse(HttpStatusCode.OK, customerAuthservices.LoginCustomer(userCred));
        }

        [HttpPost]
        public HttpResponseMessage Authenticate()
        {
            var headers = Request.Headers;

            if (headers.Contains("sportToken"))
            {
                CustomerModel customer = customerAuthservices.AuthenticateCustomer(headers.GetValues("sportToken").First());
                if (customer != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, customer);
                }
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }
}
