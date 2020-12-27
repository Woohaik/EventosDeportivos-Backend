using Api.Validators;
using Domain.Models.Customer;
using Domain.Models.ICustomerContracts;
using Domain.Services.Customer;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class LoginController : ApiController
    {

        private IAuthService customerAuthServices = CustomerService.Instance;
        private AnotationValidator<CredentialModel> validator = AnotationValidator<CredentialModel>.Instance;



        [HttpPost]
        public async Task<HttpResponseMessage> Login([FromBody] CredentialModel userCred)
        {
            validator.validate(userCred);
            IWholeAuth authModel = null;

            return await Task.Run(() =>
             {
                 try
                 {
                     authModel = this.customerAuthServices.LoginCustomer(userCred);
                     return Request.CreateResponse(HttpStatusCode.OK, authModel);
                 }
                 catch (Exception ex)
                 {
                     return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
                 }
             });

        }
    }
}
