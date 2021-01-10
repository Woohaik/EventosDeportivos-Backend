using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{



    public class AuthDto
    {

        public readonly CustomerDto customer;
        public readonly string token;
        public AuthDto (IAuthentication theAuth)
        {
            this.customer = new CustomerDto(theAuth.customer);
            this.token = theAuth.token;
        }



    }
}