using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyXpress.Models.Dtos.Request;
using Microsoft.AspNetCore.Identity;

namespace BuyXpress.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(UserSignUpRequest request);
        Task SignIn(SignInRequest request);
    }
}
