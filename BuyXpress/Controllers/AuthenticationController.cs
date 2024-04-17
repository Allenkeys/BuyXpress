using BuyXpress.Models.Dtos.Request;
using BuyXpress.Models.Dtos.Response;
using BuyXpress.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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

        [HttpPost("sign-up", Name = "Register-A-User")]
        [SwaggerOperation(Summary = "Create a new user account")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpRequest request)
        {
            IdentityResult result = await _authenticationService.SignUpAsync(request);
            return Ok(result);
        }

        [HttpPost("sign-in", Name = "Log-In-User")]
        [SwaggerOperation(Summary = "Login a user")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
        {
            AuthenticationResponse result = await _authenticationService.SignInAsync(request);
            return Ok(result);
        }
    }
}
