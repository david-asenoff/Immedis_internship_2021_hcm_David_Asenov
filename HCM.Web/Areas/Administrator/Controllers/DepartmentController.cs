using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly ICompanyService companyService;

        public DepartmentController(
            IDepartmentService departmentService,
            ICompanyService companyService)
        {
            this.departmentService = departmentService;
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await departmentService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Departments are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var companies = await this.companyService.GetAllAsDropDownAsync(true);
            var viewModel = new DepartmentAddViewModel
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
            TempData["SuccessMessage"] = "Department is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentEditViewModel model)
        {
            var companies = await this.companyService.GetAllAsDropDownAsync();
            model.Companies = companies;
            if (ModelState.IsValid)
            {
                await departmentService.EditAsync(model);
                TempData["SuccessMessage"] = "Department is edited";
                return RedirectToAction("Index", "Department");
            }

            TempData["ErrorMessage"] = "Department is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await departmentService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Department is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Department is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Department");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(DepartmentRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbDepartment = await departmentService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Department is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Department is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Department");
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddViewModel model)
        {
            var companies = await this.companyService.GetAllAsDropDownAsync(true);
            model.Companies = companies;
            if (ModelState.IsValid)
            {
                await departmentService.AddAsync(model);
                TempData["SuccessMessage"] = "Department is added";
                return RedirectToAction("Index", "Department");
            }

            TempData["ErrorMessage"] = "Department is not added. Invalid data.";

            return this.View(model);
        }
    }
}
