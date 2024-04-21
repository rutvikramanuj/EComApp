using ECom_MS.Services.AuthAPI.Models;

namespace ECom_MS.Services.AuthAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
