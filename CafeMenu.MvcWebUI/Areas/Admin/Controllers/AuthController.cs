using CafeMenu.Business.Abstract;
using CafeMenu.Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CafeMenu.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            if (ModelState.IsValid)
            {
                var userToLogin = _authService.Login(userForLoginDto);
                if (!userToLogin.Success)
                {
                    ModelState.AddModelError("UserLogin", userToLogin.Message);
                    return View(userForLoginDto);
                }

                var result = _authService.CreateAccessToken(userToLogin.Data);
                if (result.Success)
                {
                    var operationClaims = _userService.GetClaims(userToLogin.Data);
                    List<Claim> claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, userToLogin.Data.Username),
                        new Claim("Id",userToLogin.Data.UserId.ToString()),
                        new Claim("Username",userToLogin.Data.Username),
                        new Claim("Name",userToLogin.Data.Name ?? string.Empty),
                        new Claim("Name",userToLogin.Data.Surname ?? string.Empty)
                    };

                    var identity = new ClaimsIdentity(claims,
                      CookieAuthenticationDefaults.AuthenticationScheme);

                    HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
            }

            return View(userForLoginDto);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var userExists = _authService.UserExists(userForRegisterDto.Username);
                if (!userExists.Success)
                {
                    ModelState.AddModelError("UserExist", userExists.Message);
                    return View(userForRegisterDto);
                }

                var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
                var result = _authService.CreateAccessToken(registerResult.Data);
                if (result.Success)
                {
                    return Redirect("/Admin/Auth/Login");
                }
            }

            return View(userForRegisterDto);
        }

        [AllowAnonymous]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/Admin/Auth/Login");
        }
    }
}
