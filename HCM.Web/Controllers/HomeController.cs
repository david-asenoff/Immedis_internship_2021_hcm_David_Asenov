using HCM.Services.Contracts;
using HCM.Web.Models;
using HCM.Web.ViewModels.Employee;
using HCM.Web.ViewModels.Gender;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HCM.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenderService genderService;
        private readonly IUsersService usersService;

        public HomeController(ILogger<HomeController> logger, IGenderService genderService, IUsersService usersService)
        {
            _logger = logger;
            this.genderService = genderService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string txtPassword, string txtUserName)
        {
            if (txtPassword.ToLower() == "admin" && txtUserName.ToLower() == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, txtUserName)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                return RedirectToAction("Index", "Employee");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new EmployeeRegistrationViewModel();
            var genders = await this.genderService.GetAllGenders();
            ViewBag.Genders = genders;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeRegistrationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {

            }

                return this.RedirectToAction("login", "home", model);
        }

        /// <summary>
        /// A method for checking weather an email exist. Unlike for UIN, Email have to be unique.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> DoesUserEmailExist(string email)
        {
            var result = await this.usersService.DoesMailExist(email);
            return result;
        }

        /// <summary>
        /// A method for checking weather an email exist. Unlike for UIN, Email have to be unique.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<bool> DoesUserNameExist(string userName)
        {
            var result = await this.usersService.DoesUserNameExist(userName);
            return result;
        }
    }
}
