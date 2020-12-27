using Domain.Models.ICustomerContracts;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace Domain.Services.Customer.auth
{
    public class JWT
    {

        private JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

        private readonly string key = "401b09eab3c013d4ca54922bb802bec8fd5318192b0a75f201d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        public string GenerateToken(ICustomer model, bool isRefresh)
        {
           
            DateTime expiresIn = DateTime.UtcNow.AddMinutes(15);
            if (isRefresh) expiresIn = expiresIn.AddMinutes(15);           // Refresh Token Tarda mas 

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier , model.id.ToString()),
                    new Claim(ClaimTypes.Email, model.email)
                }),
                Expires = expiresIn,
                SigningCredentials = credentials
            };


            SecurityToken Thetoken = this.handler.CreateToken(tokenDescriptor);

            return this.handler.WriteToken(Thetoken);
        }

        public string decodeToken(string token)
        {
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;
            return tokenS.Claims.First(claim => claim.Type == "nameid").Value;
        }

        public bool ValidateToken(string token)
        {

            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            };

            SecurityToken validatedToken;
            IPrincipal principal = this.handler.ValidateToken(token, validationParameters, out validatedToken);
            return true;
        }



    }



}
