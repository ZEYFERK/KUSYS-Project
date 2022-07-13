using KUSYSDemo.Models;
using KUSYSDemo.Models.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace KUSYSDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }


        [Authorize]
        public IActionResult Secured()
        {
            return View();
        }


        [HttpGet("login")]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            return View();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Validate(String LoginUserName, string LoginPassword, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                using var c = new DataContext();

                var user = c.Students.FirstOrDefault(p => p.LoginUserName == LoginUserName && p.LoginPassword == LoginPassword);
                if (user != null)
                {
                    var claims = new List<Claim>();

                    claims.Add(new Claim("LoginUserName", LoginUserName));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, LoginPassword));
                    claims.Add(new Claim(ClaimTypes.Role, user.RoleId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, LoginUserName));

                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var aut_properties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(1)

                    };
                    ClaimsPrincipal principal = new ClaimsPrincipal(claimIdentity);

                    await HttpContext.SignInAsync(principal, aut_properties);
                    return Redirect(ReturnUrl);
                }
                else
                    TempData["Error"] = "Hata. Kullanıcı adı veya şifre geçersiz";
            }
            else
                TempData["Error"] = "Hata. Kullanıcı adı veya şifre geçersiz";

            return View("Login");
        }


        [Authorize]
        public async Task<IActionResult> Logout(string ReturnUrl)
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}