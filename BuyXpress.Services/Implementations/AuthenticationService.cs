using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyXpress.Models.Dtos.Request;
using BuyXpress.Models.Entities;
using BuyXpress.Models.Enums;
using BuyXpress.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BuyXpress.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationService(
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> SignUpAsync(UserSignUpRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new InvalidOperationException($"User with email: {request.Email} already exist");

            ApplicationUser user = new()
            {
                Firstname = request.Firstname,
                Middlename = request.Middlename,
                Lastname = request.Lastname,
                Email = request.Email,
                PhoneNumber = request.Phone,
                UserTypeId = request.UserTypeId,
                IsActive = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()!.Description}");

            await _userManager.AddToRoleAsync(user, request.UserTypeId.ToStringValue());

            return result;
        }
        public Task SignIn(SignInRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
