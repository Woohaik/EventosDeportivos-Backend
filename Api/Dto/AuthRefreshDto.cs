using Domain.Models.ICustomerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Dto
{
    public class AuthRefreshDto : AuthDto
    {

        public readonly string refreshToken;

        public AuthRefreshDto(IWholeAuth authTokens) : base(authTokens)
        {
            this.refreshToken = authTokens.refreshToken;
        }
    }
}