namespace HCM.Web.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Profile;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Security.Claims;
    using System.Threading.Tasks;

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IGenderService genderService;
        private readonly IUsersService usersService;

        public ProfileController(IGenderService genderService, IUsersService usersService)
        {
            this.genderService = genderService;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string username = this.User.Identity.Name;
            var model = await usersService.GetProfileAsync(username);
            model.Username = username;
            model.Genders = await this.genderService.GetAllAsDropDownAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }
            model.Username = this.User.Identity.Name;
            var user = await usersService.EditProfileAsync(model);
            model.Genders = await this.genderService.GetAllAsDropDownAsync();
            return this.View(model);
        }
    }
}
