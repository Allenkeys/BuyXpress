using System.ComponentModel.DataAnnotations;

namespace BuyXpress.Models.Dtos.Request
{
    public class UserSignUpRequest
    {
        [Required]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }

    public class SignInRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
