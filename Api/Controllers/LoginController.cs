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
    public class LoginController : ApiController
    {

        private IAuthService customerAuthServices = CustomerService.Instance;

        [HttpPost]
        public HttpResponseMessage Login([FromBody] ICredential userCred)
        {
            return Request.CreateResponse(HttpStatusCode.OK, customerAuthServices.LoginCustomer(userCred));
        }
    }
}
