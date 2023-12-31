﻿using BuyXpress.Models.Dtos.Request;
using Microsoft.AspNetCore.Identity;

namespace BuyXpress.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> SignUpAsync(UserSignUpRequest request);
        Task SignIn(SignInRequest request);
    }
}
