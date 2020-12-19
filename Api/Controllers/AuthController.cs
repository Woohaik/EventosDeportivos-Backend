using Domain.services.customer;
using Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{

    public class AuthController : ApiController
    {

        [HttpPost]
        [Route("api/auth/login")]
        public HttpResponseMessage Login([FromBody] CredentialModel userCred)
        {
            ICustomerService services = CustomerService.Instance;
            return Request.CreateResponse(HttpStatusCode.OK, services.LoginCustomer(userCred));
        }

        [HttpPost]
        public HttpResponseMessage Authenticate()
        {
            var headers = Request.Headers;

            if (headers.Contains("sportToken"))
            {
                return Request.CreateResponse(HttpStatusCode.OK , headers.GetValues("sportToken").First());
            }

            return Request.CreateResponse(HttpStatusCode.NotFound);
        }




    }
}
