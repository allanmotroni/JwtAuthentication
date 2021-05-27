using JwtAuthentication.API.Interfaces;
using JwtAuthentication.API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.API.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
            services.AddTransient<IJwtService, JwtService>();
        }
    }
}
