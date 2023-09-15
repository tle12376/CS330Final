using CS330Final;
using Microsoft.AspNetCore.Mvc;

namespace CS330Final.Controllers
{
    public class TokenRequest
    {
        public string UserEmail { get; set; }
        public string Password { get; set; }
    }

    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        // This should require SSL
        [HttpPost]
        public dynamic Post([FromBody] TokenRequest tokenRequest)
        {
            var token = TokenHelper.GetToken(tokenRequest.UserEmail, tokenRequest.Password);
            return new { Token = token };
        }

        // This should require SSL
        [HttpGet]
        public dynamic Get(string userEmail, string password)
        {
            var token = TokenHelper.GetToken(userEmail, password);
            return new { Token = token };
        }

    }
}
