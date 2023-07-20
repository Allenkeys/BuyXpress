using BuyXpress.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace BuyXpress.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public bool IsActive { get; set; }
        public UserType UserTypeId { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
