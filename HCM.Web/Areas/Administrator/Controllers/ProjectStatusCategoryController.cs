using System.Threading.Tasks;
using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.ProjectStatusCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ProjectStatusCategoryController : Controller
    {
        private readonly IProjectStatusCategoryService projectStatusCategoryService;

        public ProjectStatusCategoryController(IProjectStatusCategoryService projectStatusCategoryService)
        {
            this.projectStatusCategoryService = projectStatusCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await projectStatusCategoryService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Project Status Categories are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var model = await projectStatusCategoryService.GetAsync(id);
            TempData["SuccessMessage"] = "Project Status Category is loaded";

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProjectStatusCategoryEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await projectStatusCategoryService.EditAsync(model);
                TempData["SuccessMessage"] = "Project Status Category is edited";
                return RedirectToAction("Index", "ProjectStatusCategory");
            }

            TempData["ErrorMessage"] = "Project Status Category is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProjectStatusCategoryDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbProjectStatusCategory = await projectStatusCategoryService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Project Status Category is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Project Status Category is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ProjectStatusCategory");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(ProjectStatusCategoryRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbProjectStatusCategory = await projectStatusCategoryService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Project Status Category is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Project Status Category is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ProjectStatusCategory");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProjectStatusCategoryAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await projectStatusCategoryService.AddAsync(model);
                TempData["SuccessMessage"] = "Project Status Category is added";
                return RedirectToAction("Index", "ProjectStatusCategory");
            }

            TempData["ErrorMessage"] = "Project Status Category is not added. Invalid data.";

            return this.View(model);
        }
    }
}
