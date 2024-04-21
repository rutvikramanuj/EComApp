using ECom_MS.Services.AuthAPI.Models.Dtos;

namespace ECom_MS.Services.AuthAPI.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto request);
        Task<LoginResponseDto> Login(LoginRequestDto request);
        Task<bool> AssignRole(string email, string roleName);
    }
}
