using HCM.Services.Contracts;
using HCM.Web.ViewModels.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HCM.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IDashboardService genderService;
        private readonly IUsersService usersService;
        private readonly IProfileService profileService;
        private readonly IWebHostEnvironment environment;

        public ProfileController(IDashboardService genderService, 
            IUsersService usersService, 
            IProfileService profileService,
            IWebHostEnvironment environment)
        {
            this.genderService = genderService;
            this.usersService = usersService;
            this.profileService = profileService;
            this.environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string username = this.User.Identity.Name;
            var model = await profileService.GetAsync(username);
            model.Username = username;
            model.Genders = await this.genderService.GetAllAsDropDownAsync();
            TempData["SuccessMessage"] = "Profile is loaded";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {

            if (!this.ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Profile is not edited. Invalid data.";
                model.Genders = await this.genderService.GetAllAsDropDownAsync();
                return View(model);
            }
            try
            {
                model.Username = this.User.Identity.Name;
                var user = await profileService.EditAsync(model, $"{this.environment.WebRootPath}/images");
                model.Genders = await this.genderService.GetAllAsDropDownAsync();
                return this.View(model);
            }
            catch (ArgumentException ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.RedirectToAction(nameof(this.Index));
            }
            
        }
    }
}
