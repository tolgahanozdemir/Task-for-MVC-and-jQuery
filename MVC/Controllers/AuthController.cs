using Business.Abstract;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MVC.Controllers
{
    //[Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : Controller
    {
        private IAuthService _authService;
        private IHttpContextAccessor _httpContextAccessor;
        private IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                ViewBag.ErrMsg = userExists.Message;
                return View();
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                ViewBag.Success = "Kullanıcı Oluşturuldu.";
                return View();
            }
            ViewBag.ErrMsg = result.Message;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            var userClaims = _userService.GetClaims(userToLogin.Data);
            if (!userToLogin.Success)
            {
                ViewBag.ErrMsg = userToLogin.Message;
                return View();
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                List<Claim> claims = new List<Claim> {
                        new Claim(userForLoginDto.Email,userToLogin.Data.Email),
                };
                
                claims.AddRange(userClaims.Select(x=> new Claim(x.Id.ToString(),x.Name)));

                var identity = new ClaimsIdentity(claims,
                  JwtBearerDefaults.AuthenticationScheme);
                



                await _httpContextAccessor.HttpContext.SignInAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme,
                  new ClaimsPrincipal(identity));

                return View("../Home/Homepage");
            }

            ViewBag.ErrMsg = result.Message;
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            ViewBag.Success = "Email hesabınız doğru ise hesabınıza mail gönderilecektir.";
            return View("../Auth/Login");
        }
    }
}
