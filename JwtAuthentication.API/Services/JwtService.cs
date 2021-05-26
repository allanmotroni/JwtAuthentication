using JwtAuthentication.API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.API.Services
{
    public class JwtService : IJwtService
    {
        private readonly string secret;
        private readonly string expirationInMinutes;
        public JwtService(IConfiguration configuration)
        {
            secret = configuration["JwtConfiguration:secret"];
            expirationInMinutes = configuration["JwtConfiguration:expirationInMinutes"];
        }

        public string GenerateSecurityToken(string email)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(secret);
            
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor { 
                Subject = new System.Security.Claims.ClaimsIdentity(),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(expirationInMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

    }

}
