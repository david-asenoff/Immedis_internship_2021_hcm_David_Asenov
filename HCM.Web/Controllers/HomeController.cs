using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.Models;
using HCM.Web.ViewModels.Employee;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IDashboardService dashboardService;

        public HomeController(ILogger<HomeController> logger, IGenderService genderService, IUsersService usersService, IDashboardService dashboardService)
        {
            _logger = logger;
            this.genderService = genderService;
            this.usersService = usersService;
            this.dashboardService = dashboardService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            if (!this.User.IsInRole(GlobalConstants.EmployeeRoleName))
            {
                return RedirectToAction("ManagementStatistics", "Home");
            }
            var model = await this.dashboardService.GetEmployeeAllContractsSummaryAsync(this.User.Identity.Name);
            return this.View(model);
        }

        [Authorize]
        public async Task<IActionResult> ManagementStatistics()
        {
            var model = await this.dashboardService.GetManagementSummaryAsync();
            return this.View(model);
        }

        [Authorize]
        public IActionResult MyStatistics()
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

        public IActionResult StatusCodeError(int errorCode)
        {
            return this.View();
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
                var props = new AuthenticationProperties() { IsPersistent = model.RememberMe };
                if (model.RememberMe)
                {
                    props.ExpiresUtc = DateTimeOffset.UtcNow.AddDays(10);
                }
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
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
            return RedirectToAction("Login");
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
