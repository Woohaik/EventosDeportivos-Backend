using Domain.Models.ICustomerContracts;
using Domain.Services.Customer;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Api.Validators;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class AuthController : ApiController
    {

        private IAuthService customerAuthServices = CustomerService.Instance;
        private AuthValidator validator = new AuthValidator();

        [HttpPost]
        public async Task<HttpResponseMessage> Authenticate()
        {
            try
            {
                validator.authvalidator(Request.Headers, customerAuthServices);
                IAuthentication theAuthentication = await this.customerAuthServices.GetAuthenticatedCustomer(Convert.ToInt32(Request.Headers.GetValues("CustomerId").First()));
                if (theAuthentication == null) throw new Exception("No existe Cliente con ese Id");
                return Request.CreateResponse(HttpStatusCode.OK, theAuthentication);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, ex);
            }



        }
    }
}
