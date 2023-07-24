using BuyXpress.Models.Dtos.Request;
using BuyXpress.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuyXpress.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        [HttpPost("sign-up", Name = "Register a user")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpRequest request)
        {
            IdentityResult result = await _authenticationService.SignUpAsync(request);
            return Ok(result);
        }
    }
}
