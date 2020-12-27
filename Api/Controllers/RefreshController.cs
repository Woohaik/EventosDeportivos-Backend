using Api.Dto;
using Api.Validators;
using Domain.Models.ICustomerContracts;
using Domain.Services.Customer;
using Domain.Services.IServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api.Controllers
{
    public class RefreshController : ApiController
    {
        private IAuthService customerAuthServices = CustomerService.Instance;
        private AuthValidator validator = new AuthValidator();

        [HttpPost]
        public async Task<HttpResponseMessage> RefreshToken()
        {
            try
            {
                var header = Request.Headers;
                validator.authvalidator(header, customerAuthServices);
                int customerID = Convert.ToInt32(header.GetValues("CustomerId").First());
                IWholeAuth newAuthTokens = await this.customerAuthServices.RefreshToken(customerID, header.GetValues("sportToken").First());
                AuthTokenDto authCustomerTokensDto = new AuthTokenDto(newAuthTokens);
                return Request.CreateResponse(HttpStatusCode.OK, authCustomerTokensDto);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, ex);
            }

        }
    }
}
