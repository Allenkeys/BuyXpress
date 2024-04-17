using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyXpress.Models.Dtos.Response
{
    public class AuthenticationResponse
    {
        public JwtToken JwtToken { get; set; }
        public string UserId { get; set; }

        public string FullName { get; set; }
        public string UserType { get; set; }
    }

    public class JwtToken
    {
        public string Token { get; set; }
        public DateTime Issued { get; set; } = DateTime.Now;
        public DateTime Expiration { get; set; }
    }
}
