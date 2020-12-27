using Api.Dto;
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
            try
            {
                validator.validate(userCred);
                IWholeAuth authModel = await customerAuthServices.LoginCustomer(userCred);
                AuthTokenDto authCustomerTokensDto = new AuthTokenDto(authModel);
                return Request.CreateResponse(HttpStatusCode.OK, authCustomerTokensDto);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }


        }
    }
}
