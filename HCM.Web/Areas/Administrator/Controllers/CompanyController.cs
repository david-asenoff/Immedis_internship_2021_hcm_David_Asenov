namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await companyService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Companies are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var model = await companyService.GetAsync(id);
            TempData["SuccessMessage"] = "Company is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CompanyEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await companyService.EditAsync(model);
                TempData["SuccessMessage"] = "Company is edited";
                return RedirectToAction("Index", "Company");
            }

            TempData["ErrorMessage"] = "Company is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CompanyDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await companyService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Company is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Company is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Company");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(CompanyRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbCompany = await companyService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Company is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Company is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Company");
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await companyService.AddAsync(model);
                TempData["SuccessMessage"] = "Company is added";
                return RedirectToAction("Index", "Company");
            }

            TempData["ErrorMessage"] = "Company is not added. Invalid data.";

            return this.View(model);
        }
    }
}
