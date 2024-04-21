using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;
using EComApp.Web.Utility;

namespace EComApp.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService baseService;

        public AuthService(IBaseService baseService)
        {
            this.baseService = baseService;
        }

        public async Task<ResponseDto?> AssignRole(RegistrationRequestDto requestDto)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthApi + "/api/Auth/AssignRole",
                Data = requestDto
            };
            return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> Login(LoginRequestDto requestDto)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthApi + "/api/Auth/Login",
                Data = requestDto
            };
            return await baseService.SendAsync(request);
        }

        public async Task<ResponseDto?> Register(RegistrationRequestDto requestDto)
        {
            RequestDto request = new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Url = SD.AuthApi + "/api/Auth/Register",
                Data = requestDto
            };
            return await baseService.SendAsync(request);
        }
    }
}
