using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Motorport.Infrastructure.Util.Authentication
{
    public sealed class MotorportToken
    {
        private static MotorportToken instance = null;

        private SymmetricSecurityKey _symmetricSecurityKey = null;

        private SigningCredentials _signingCredentials = null;

        private string _issuer = "motorport-core-api.azurewebsites.net";

        private string _audience = "readers";

        private MotorportToken(string securityKey)
        {
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        public static MotorportToken Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MotorportToken("this_is_our_supper_long_security_key_for_motorport_authentication_2019$");
                }
                return instance;
            }
        }

        public string GetToken()
        {
            //create token
            var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: _signingCredentials
                );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GetToken(List<Claim> claims)
        {
            //create token
            var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: _signingCredentials, 
                    claims: claims
                );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public TokenValidationParameters GetTokenValidationParameters() => new TokenValidationParameters
        {
            //what to validate
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            //setup validate data
            ValidIssuer = _issuer,
            ValidAudience = _audience,
            IssuerSigningKey = _symmetricSecurityKey
        };


    }
}
