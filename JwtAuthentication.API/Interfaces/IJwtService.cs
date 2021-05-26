using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtAuthentication.API.Interfaces
{
    public interface IJwtService
    {
        public string GenerateSecurityToken(string email);
    }
}
