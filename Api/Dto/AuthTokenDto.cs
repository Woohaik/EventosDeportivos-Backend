using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class AuthTokenDto
    {
        public readonly CustomerDto customer;
        public readonly string token;
        public readonly string refreshToken;

        public AuthTokenDto(IWholeAuth authTokens)
        {
            this.customer = new CustomerDto(authTokens.customer);
            this.token = authTokens.token;
            this.refreshToken = authTokens.refreshToken;
        }
    }
}