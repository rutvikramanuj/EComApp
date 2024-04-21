using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;
using EComApp.Web.Service;
using EComApp.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;

namespace EComApp.Web.Controllers
{
    public class AuthController : Controller
    {
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IAuthService _authService{ get; }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto request = new();
            return View(request);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {
                    Text= SD.RoleAdmin,Value=SD.RoleAdmin
                },
                new SelectListItem() {
                    Text= SD.RoleEmployee,Value=SD.RoleEmployee
                },
            };
            ViewBag.RoleList = roleList;
            RegistrationRequestDto request = new();
            return View(request);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto request)
        {
            ResponseDto response = await _authService.Register(request);
            ResponseDto assignRole;
            if (response != null && response.isSuccess)
            {
                if (string.IsNullOrEmpty(request.Role))
                {
                    request.Role = SD.RoleEmployee;
                }
                assignRole = await _authService.AssignRole(request);
                if (assignRole != null && assignRole.isSuccess)
                {
                    TempData["success"] = "Registration Successfull";
                    return RedirectToAction(nameof(Login));
                }
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem() {
                    Text= SD.RoleAdmin,Value=SD.RoleAdmin
                },
                new SelectListItem() {
                    Text= SD.RoleEmployee,Value=SD.RoleEmployee
                },
            };
            ViewBag.RoleList = roleList;
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            ResponseDto response = await _authService.Login(request);
            if (response != null)
            {
                LoginResponseDto responseDTO = JsonSerializer.Deserialize<LoginResponseDto>(response.result.ToString());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = response.message;
            }
            return View(request);
        }
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
