namespace HCM.Web.Areas.Manager.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area(GlobalConstants.ManagerRoleName)]
    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ICompanyService companyService;

        public ProjectController(
            IProjectService departmentService,
            ICompanyService companyService)
        {
            this.projectService = departmentService;
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await projectService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Projects are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            var viewModel = new ProjectAddViewModel
            {
                Companies = await this.companyService.GetAllAsDropDownAsync(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var model = await projectService.GetAsync(id);
            model.Companies = await this.companyService.GetAllAsDropDownAsync();
            TempData["SuccessMessage"] = "Project is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectEditViewModel model)
        {
            model.Companies = await this.companyService.GetAllAsDropDownAsync(); ;
            if (ModelState.IsValid)
            {
                await projectService.EditAsync(model);
                TempData["SuccessMessage"] = "Project is edited";
                return RedirectToAction("Index", "Project");
            }

            TempData["ErrorMessage"] = "Project is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProjectDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await projectService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Project is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Project is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Project");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(ProjectRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbProject = await projectService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Project is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Project is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Project");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectAddViewModel model)
        {
            model.Companies = await this.companyService.GetAllAsDropDownAsync();
            if (ModelState.IsValid)
            {
                await projectService.AddAsync(model);
                TempData["SuccessMessage"] = "Project is added";
                return RedirectToAction("Index", "Project");
            }

            TempData["ErrorMessage"] = "Project is not added. Invalid data.";

            return this.View(model);
        }
    }
}
