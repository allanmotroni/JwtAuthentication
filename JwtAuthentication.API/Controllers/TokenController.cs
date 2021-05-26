using JwtAuthentication.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IJwtService jwtService;
        public TokenController(IJwtService jwtService)
        {            
            this.jwtService = jwtService;
        }

        [HttpGet]
        public string GetRandomToken()
        {
            string email = "teste@teste.com";
            string token = jwtService.GenerateSecurityToken(email);
            return token;
        }
    }
}
