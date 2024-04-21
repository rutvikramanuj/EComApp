using Microsoft.AspNetCore.Identity;

namespace ECom_MS.Services.AuthAPI.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
