using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Entities.Concrete.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace MVC.Controllers
{
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
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                ViewBag.ErrMsg = userToLogin.Message;
                return View();
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return View("../Home/Homepage");
            }

            ViewBag.ErrMsg = result.Message;
            return View();
        }
    }
}
