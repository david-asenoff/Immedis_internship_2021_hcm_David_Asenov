using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Manager.Controllers
{
    [Area(GlobalConstants.ManagerRoleName)]
    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ICompanyService companyService;
        private readonly IEmployeeProjectService employeeProjectService;

        public ProjectController(
            IProjectService departmentService,
            ICompanyService companyService,
            IEmployeeProjectService employeeProjectService)
        {
            this.projectService = departmentService;
            this.companyService = companyService;
            this.employeeProjectService = employeeProjectService;
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
        public async Task<IActionResult> Edit(string projectId)
        {
            var model = await employeeProjectService.GetAsync(projectId);
            model.Project.Companies = await this.companyService.GetAllAsDropDownAsync();
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

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(string projectId, string employeeId)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                await employeeProjectService.DeleteAsync(projectId, employeeId);
                TempData["SuccessMessage"] = "Employee was removed from this project";
                return RedirectToAction("Edit", "Project", new { projectId = projectId });
            }

            TempData["ErrorMessage"] = "Employee is not removed from the project. Invalid data.";
            return RedirectToAction("Edit", "Project", new { projectId = projectId });
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(string projectId, string employeeId)
        {
            var model = await employeeProjectService.AddAsync(projectId, employeeId);
            TempData["SuccessMessage"] = "Participant is added";
            return RedirectToAction("Edit", "Project", new { projectId = projectId });
        }
    }
}
