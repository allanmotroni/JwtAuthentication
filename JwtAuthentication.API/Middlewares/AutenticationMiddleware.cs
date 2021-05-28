using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JwtAuthentication.API.Middlewares
{
    public static class AutenticationMiddleware
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            string secret = configuration["JwtConfiguration:secret"];
            byte[] key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false                    
                };
            });

            return services;
        }
    }
}
