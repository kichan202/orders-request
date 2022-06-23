using ITDepartment.Data;
using ITDepartment.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using
    System.Security;
using System.Security.Claims;

namespace ITDepartment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext _DB;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext DB)
        {
            _logger = logger;
            _DB = DB;
        }

        //Get
        public IActionResult Login()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User obj)
        {
            bool isExist = false;
            isExist = _DB.Users.Where(x => (x.name.Trim().ToLower() == obj.name.Trim().ToLower()) &&
            x.lastName.Trim().ToLower() == obj.lastName.Trim().ToLower()).Any();

            var department = _DB.Users.Where(x => (x.name.Trim().ToLower() == obj.name.Trim().ToLower()) && x.lastName.Trim().ToLower() == obj.lastName.Trim().ToLower()).Select(x=> x.Department.DepartmentName).FirstOrDefault();
            var userLevel = _DB.Users.Where(x => (x.name.Trim().ToLower() == obj.name.Trim().ToLower()) && x.lastName.Trim().ToLower() == obj.lastName.Trim().ToLower()).Select(x=> x.Role.roleId).FirstOrDefault().ToString();
        

            if (isExist)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, obj.name),
                    new Claim("Department",  department),
                    new Claim("Role", userLevel)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                return View("Login");
            }

        }

        //LogOut
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View(); //edit
        }

    }
}