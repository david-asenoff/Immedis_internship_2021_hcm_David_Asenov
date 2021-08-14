using System.Threading.Tasks;
using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.MaritalStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class MaritalStatusController : Controller
    {
        private readonly IMaritalStatusService maritalStatusService;

        public MaritalStatusController(IMaritalStatusService maritalStatusService)
        {
            this.maritalStatusService = maritalStatusService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await maritalStatusService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Marital Statuses are loaded";
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MaritalStatusEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbMaritalStatus = await maritalStatusService.EditAsync(model);
                TempData["SuccessMessage"] = "Marital Status is edited";
            }
            else
            {
                TempData["ErrorMessage"] = "Marital Status is not edited. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "MaritalStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MaritalStatusDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbMaritalStatus = await maritalStatusService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Marital Status is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Marital Status is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "MaritalStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(MaritalStatusRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbMaritalStatus = await maritalStatusService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Marital Status is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Marital Status is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "MaritalStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Add(MaritalStatusAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbMaritalStatus = await maritalStatusService.AddAsync(model);
                TempData["SuccessMessage"] = "Marital Status is added";
            }
            else
            {
                TempData["ErrorMessage"] = "Marital Status is not added. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "MaritalStatus");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var model = await maritalStatusService.GetAsync(id);
            TempData["SuccessMessage"] = "Marital Status is loaded";

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }
    }
}
