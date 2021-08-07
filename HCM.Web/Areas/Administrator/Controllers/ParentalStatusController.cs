namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.ParentalStatus;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ParentalStatusController : Controller
    {
        private readonly IParentalStatusService parentalStatusService;

        public ParentalStatusController(IParentalStatusService parentalStatusService)
        {
            this.parentalStatusService = parentalStatusService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await parentalStatusService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Parental Statuses are loaded";
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParentalStatusEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbParentalStatus = await parentalStatusService.EditAsync(model);
                TempData["SuccessMessage"] = "Parental Status is edited";
            }
            else
            {
                TempData["ErrorMessage"] = "Parental Status is not edited. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ParentalStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ParentalStatusDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbParentalStatus = await parentalStatusService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Parental Status is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Parental Status is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ParentalStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(ParentalStatusRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbParentalStatus = await parentalStatusService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Parental Status is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Parental Status is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ParentalStatus");
        }

        [HttpPost]
        public async Task<IActionResult> Add(ParentalStatusAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbParentalStatus = await parentalStatusService.AddAsync(model);
                TempData["SuccessMessage"] = "Parental Status is added";
            }
            else
            {
                TempData["ErrorMessage"] = "Parental Status is not added. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "ParentalStatus");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var model = await parentalStatusService.GetAsync(id);
            TempData["SuccessMessage"] = "Parental Status is loaded";

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }
    }
}
