using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Currency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await currencyService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Currencies are loaded";
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

            var model = await currencyService.GetAsync(id);
            TempData["SuccessMessage"] = "Currency is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CurrencyEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await currencyService.EditAsync(model);
                TempData["SuccessMessage"] = "Currency is edited";
                return RedirectToAction("Index", "Currency");
            }

            TempData["ErrorMessage"] = "Currency is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CurrencyDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await currencyService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Currency is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Currency is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Currency");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(CurrencyRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbCurrency = await currencyService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Currency is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Currency is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Currency");
        }

        [HttpPost]
        public async Task<IActionResult> Add(CurrencyAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await currencyService.AddAsync(model);
                TempData["SuccessMessage"] = "Currency is added";
                return RedirectToAction("Index", "Currency");
            }

            TempData["ErrorMessage"] = "Currency is not added. Invalid data.";

            return this.View(model);
        }
    }
}
