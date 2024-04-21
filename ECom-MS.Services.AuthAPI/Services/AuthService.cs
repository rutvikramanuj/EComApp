using ECom_MS.Services.AuthAPI.Data;
using ECom_MS.Services.AuthAPI.Models;
using ECom_MS.Services.AuthAPI.Models.Dtos;
using Microsoft.AspNetCore.Identity;

namespace ECom_MS.Services.AuthAPI.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(
            DataContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IJwtTokenGenerator tokenGenerator
            
            ){
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenGenerator = tokenGenerator;
        }

        public DataContext _context { get; }
        public UserManager<ApplicationUser> _userManager { get; }
        public RoleManager<IdentityRole> _roleManager { get; }
        public IJwtTokenGenerator _tokenGenerator { get; }

        public async Task<LoginResponseDto> Login(LoginRequestDto request)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(x => x.UserName.ToLower() == request.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, request.Password);
            if (isValid == false || user == null)
            {
                return new LoginResponseDto()
                {
                    User = null,
                    Token = ""
                };
            }
            else
            {
                UserDto userDto = new()
                {
                    Email = user.Email,
                    Name = user.Name,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber
                };
                return new LoginResponseDto()
                {
                    User = userDto,
                    Token = _tokenGenerator.GenerateToken(user)
                };
            }
        }

        public async Task<string> Register(RegistrationRequestDto request)
        {
            ApplicationUser user = new()
            {
                UserName = request.Email,
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
            };
            try
            {
            var result = await _userManager.CreateAsync(user,request.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _context.ApplicationUsers.First(user => user.UserName == request.Email);
                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        Id = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        public async Task<bool> AssignRole(string email,string roleName)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();

                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            else {
                return false;
              }
        }
    }
}
