using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ProjectController : Controller
    {
        private readonly IProjectService departmentService;
        private readonly ICompanyService companyService;

        public ProjectController(
            IProjectService departmentService,
            ICompanyService companyService)
        {
            this.departmentService = departmentService;
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await departmentService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Projects are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var companies = await this.companyService.GetAllAsDropDownAsync(true);
            var viewModel = new ProjectAddViewModel
            {
                Companies = companies,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var companies = await this.companyService.GetAllAsDropDownAsync(true);
            var model = await departmentService.GetAsync(id);
            model.Companies = companies;
            TempData["SuccessMessage"] = "Project is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProjectEditViewModel model)
        {
            var companies = await this.companyService.GetAllAsDropDownAsync(true);
            model.Companies = companies;
            if (ModelState.IsValid)
            {
                await departmentService.EditAsync(model);
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
                await departmentService.DeleteAsync(model);
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
                var dbProject = await departmentService.RestoreAsync(model);
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
            var companies = await this.companyService.GetAllAsDropDownAsync(true);
            model.Companies = companies;
            if (ModelState.IsValid)
            {
                await departmentService.AddAsync(model);
                TempData["SuccessMessage"] = "Project is added";
                return RedirectToAction("Index", "Project");
            }

            TempData["ErrorMessage"] = "Project is not added. Invalid data.";

            return this.View(model);
        }
    }
}
