using BuyXpress.Models.Dtos.Request;
using BuyXpress.Models.Dtos.Response;
using Microsoft.AspNetCore.Identity;

namespace BuyXpress.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(UserSignUpRequest request);
        Task<AuthenticationResponse> SignInAsync(SignInRequest request);
    }
}
