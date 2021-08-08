namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.ProjectStatus;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ProjectStatusController : Controller
    {
        private readonly IProjectStatusService projectStatusService;
        private readonly IProjectStatusCategoryService projectStatusCategoryService;
        private readonly IProjectService projectService;

        public ProjectStatusController(
            IProjectStatusService projectStatusService,
            IProjectStatusCategoryService projectStatusCategoryService,
            IProjectService projectService)
        {
            this.projectStatusService = projectStatusService;
            this.projectStatusCategoryService = projectStatusCategoryService;
            this.projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await projectStatusService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Project Statuses are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var projectStatusCategories = await this.projectStatusCategoryService.GetAllAsDropDown();
            var projects = await this.projectService.GetAllAsDropDown();
            var viewModel = new ProjectStatusAddViewModel
            {
                ProjectStatusCategories = projectStatusCategories,
                Projects = projects,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var projectStatusCategories = await this.projectStatusCategoryService.GetAllAsDropDown();
            var projects = await this.projectService.GetAllAsDropDown();
            var model = await projectStatusService.GetAsync(id);
            model.ProjectStatusCategories = projectStatusCategories;
            model.Projects = projects;
            TempData["SuccessMessage"] = "Project Status is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectStatusEditViewModel model)
        {
            var projectStatusCategories = await this.projectStatusCategoryService.GetAllAsDropDown();
            var projects = await this.projectService.GetAllAsDropDown();
            model.Projects = projects;
            model.ProjectStatusCategories = projectStatusCategories;
            if (ModelState.IsValid)
            {
                await projectStatusService.EditAsync(model);
                TempData["SuccessMessage"] = "ProjectStatus is edited";
                return RedirectToAction("Index", "ProjectStatus");
            }

            TempData["ErrorMessage"] = "ProjectStatus is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProjectStatusDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await projectStatusService.DeleteAsync(model);
                TempData["SuccessMessage"] = "ProjectStatus is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "ProjectStatus is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ProjectStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(ProjectStatusRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbProjectStatus = await projectStatusService.RestoreAsync(model);
                TempData["SuccessMessage"] = "ProjectStatus is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Project Status is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ProjectStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectStatusAddViewModel model)
        {
            var projectStatusCategories = await this.projectStatusCategoryService.GetAllAsDropDown();
            var projects = await this.projectService.GetAllAsDropDown();
            model.Projects = projects;
            model.ProjectStatusCategories = projectStatusCategories;
            if (ModelState.IsValid)
            {
                await projectStatusService.AddAsync(model);
                TempData["SuccessMessage"] = "Project Status is added";
                return RedirectToAction("Index", "ProjectStatus");
            }

            TempData["ErrorMessage"] = "Project Status is not added. Invalid data.";

            return this.View(model);
        }
    }
}
