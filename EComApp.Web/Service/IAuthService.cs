using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;

namespace EComApp.Web.Service
{
    public interface IAuthService
    {

        Task<ResponseDto?> Register(RegistrationRequestDto request);
        Task<ResponseDto?> Login(LoginRequestDto request);
        Task<ResponseDto?> AssignRole(RegistrationRequestDto request);
    }
}
