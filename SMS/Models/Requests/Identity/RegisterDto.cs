using Microsoft.AspNetCore.Components.Forms;
using SMS.Models.Constants;

namespace SMS.Models.Requests.Identity
{
    public class RegisterDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string? PhoneNumber { get; set; }

        public GenderType Gender { get; set; }

        public string? Address { get; set; }

        public IBrowserFile? ImageUrl { get; set; }
    }
}
