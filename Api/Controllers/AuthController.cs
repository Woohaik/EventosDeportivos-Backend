using Domain.Models.ICustomerContracts;
using Domain.Services.Customer;
using Domain.Services.IServicesContracts;
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

        private IAuthService customerAuthServices = CustomerService.Instance;

        [HttpPost]
        public HttpResponseMessage Authenticate()
        {
            var headers = Request.Headers;

            if (headers.Contains("sportToken"))
            {
                ICustomer customer = this.customerAuthServices.AuthenticateCustomer(headers.GetValues("sportToken").First());
                if (customer != null) return Request.CreateResponse(HttpStatusCode.OK, customer);
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
    }
}
