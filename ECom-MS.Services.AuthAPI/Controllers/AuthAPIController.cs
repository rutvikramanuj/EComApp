using ECom_MS.Services.AuthAPI.Models.Dtos;
using ECom_MS.Services.AuthAPI.Services;
using ECom_MS.Services.CouponAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom_MS.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        public IAuthService _authService { get; }
        protected ResponseDto _response;
        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequestDto request)
        {
            var errorMessage = await _authService.Register(request);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                _response.IsSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            else
            {
                _response.IsSuccess = true;
                _response.Message = "";
            return Ok(_response);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var loginResponse = await _authService.Login(request);
            if (loginResponse.User == null)
            {
                _response.IsSuccess = false;
                _response.Message = "Username or password is incorrect";
                return BadRequest(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto model)
        {
            var assignRoleSuccessfull = await _authService.AssignRole(model.Email,model.Role.ToUpper());
            if (!assignRoleSuccessfull)
            {
                _response.IsSuccess = false;
                _response.Message = "Error Encounterd";
                return BadRequest(_response);
            }
            _response.Result = assignRoleSuccessfull;
            return Ok(_response);
        }
    }
}
