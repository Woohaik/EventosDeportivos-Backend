﻿using Domain.Models.ICustomerContracts;
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
using Api.Dto;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [EnableCors("*", "*", "*")]
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
                int customerID = Convert.ToInt32(Request.Headers.GetValues("CustomerId").First());
                IAuthentication theAuthentication = await this.customerAuthServices.GetAuthenticatedCustomer(customerID);
                if (theAuthentication == null) throw new Exception("No existe Cliente con ese Id");
                return Request.CreateResponse(HttpStatusCode.OK, new AuthDto(theAuthentication));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new ErrorDto(ex));
            }



        }
    }
}
