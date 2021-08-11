using HCM.Services.Contracts;
using HCM.Web.Models;
using HCM.Web.ViewModels.Employee;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        public async Task<IActionResult> Login(EmployeeLoginViewModel model)
        {
            var result = await this.usersService.DoesUserNameAndPasswordCombinationExist(model);
            if (result)
            {
                var dbUser = await this.usersService.GetUserByUserName(model.Username);
                if (dbUser.IsBanned)
                {
                    throw new ArgumentException("User is temporarily banned. Ask Administrator for more information.");
                }
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, dbUser.Role.Type),
                    new Claim(ClaimTypes.Email, dbUser.Email),
                    new Claim("FullName", dbUser.FirstName + " " + dbUser.LastName),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
                TempData["SuccessMessage"] = "Successfull login";
                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMessage"] = "Invalid username or password";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            TempData["SuccessMessage"] = "Successfull logout";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            var model = new EmployeeRegistrationViewModel();
            var genders = await this.genderService.GetAllAsync();
            ViewBag.Genders = genders;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeRegistrationViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                var genders = await this.genderService.GetAllAsync();
                ViewBag.Genders = genders;
                TempData["ErrorMessage"] = "Registration is not successful. Invalid data.";
                return View(model);
            }

            var user = await usersService.CreateEmployeeAsync(model);
            TempData["SuccessMessage"] = "Successful registration";
            return this.RedirectToAction("Login", "Home", user.Username);
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
