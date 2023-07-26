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
        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(UserSignUpRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser != null)
                throw new InvalidOperationException($"User with email: {request.Email} already exist");

            ApplicationUser user = new()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = request.Firstname,
                Middlename = request.Middlename,
                Lastname = request.Lastname,
                Email = request.Email,
                UserName = request.Username,
                UserTypeId = request.UserTypeId,
                IsActive = true
            };

            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new InvalidOperationException($"Failed to create user: {result.Errors.FirstOrDefault()!.Description}");

            await _userManager.AddToRoleAsync(user, request.UserTypeId.ToStringValue());

            return result;
        }
        public async Task<IEnumerable<string>> SignIn(SignInRequest request)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);
            bool isValidPassword = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValidPassword || user is null)
                throw new InvalidOperationException("Invalid email or password");

            if (!user.IsActive)
                throw new InvalidOperationException("Account is inactive");

            string userType = user.UserTypeId.ToStringValue()!;

            string fullname = string.IsNullOrWhiteSpace(user.Middlename)
                ? $"{user.Firstname} {user.Lastname}"
                : $"{user.Firstname} {user.Middlename} {user.Lastname}";

            return new List<string>() { fullname, userType };
        }
    }
}
