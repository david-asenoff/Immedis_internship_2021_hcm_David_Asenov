namespace HCM.Web.Controllers
{
using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.ManageUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
  
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageUserController : Controller
    {
        private readonly IGenderService genderService;
        private readonly IUsersService usersService;
        private readonly IManageUserService manageUserService;
        private readonly IWebHostEnvironment environment;

        public ManageUserController(IGenderService genderService, 
            IUsersService usersService, 
            IManageUserService manageUserService,
            IWebHostEnvironment environment)
        {
            this.genderService = genderService;
            this.usersService = usersService;
            this.manageUserService = manageUserService;
            this.environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var result = await manageUserService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Users are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await manageUserService.GetAsync(id);
            TempData["SuccessMessage"] = "User is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ManageUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                await manageUserService.EditAsync(model);
                TempData["SuccessMessage"] = "User is edited";
                return RedirectToAction("Index", "ManageUser");
            }

            TempData["ErrorMessage"] = "User is not edited. Invalid data.";
            return this.View(model);
        }
    }
}
