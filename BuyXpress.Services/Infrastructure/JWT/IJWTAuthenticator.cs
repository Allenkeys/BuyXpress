using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BuyXpress.Models.Dtos.Response;
using BuyXpress.Models.Entities;

namespace BuyXpress.Services.Infrastructure.JWT
{
    public interface IJWTAuthenticator
    {
        public Task<JwtToken> GenerateTokenAsync(ApplicationUser user, string expiration = null, IList<Claim> claims = null);
    }
}
