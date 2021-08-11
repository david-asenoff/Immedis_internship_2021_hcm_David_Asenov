namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Salary;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class SalaryController : Controller
    {
        private readonly ISalaryService salaryService;
        private readonly IPaymentIntervalService paymentIntervalService;
        private readonly ICurrencyService currencyService;

        public SalaryController(
            ISalaryService salaryService,
            IPaymentIntervalService paymentIntervalService,
            ICurrencyService currencyService)
        {
            this.salaryService = salaryService;
            this.paymentIntervalService = paymentIntervalService;
            this.currencyService = currencyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await salaryService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Salaries are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var paymentIntervals = await this.paymentIntervalService.GetAllAsDropDownAsync();
            var currencies = await this.currencyService.GetAllAsDropDownAsync();
            var viewModel = new SalaryAddViewModel
            {
                PaymentIntervals = paymentIntervals,
                Currencies = currencies,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var paymentIntervals = await this.paymentIntervalService.GetAllAsDropDownAsync();
            var currencies = await this.currencyService.GetAllAsDropDownAsync();
            var model = await salaryService.GetAsync(id);
            model.Currencies = currencies;
            model.PaymentIntervals = paymentIntervals;
            TempData["SuccessMessage"] = "Salary is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SalaryEditViewModel model)
        {
            var paymentIntervals = await this.paymentIntervalService.GetAllAsDropDownAsync();
            var currencies = await this.currencyService.GetAllAsDropDownAsync();
            model.Currencies = currencies;
            model.PaymentIntervals = paymentIntervals;
            if (ModelState.IsValid)
            {
                await salaryService.EditAsync(model);
                TempData["SuccessMessage"] = "Salary is edited";
                return RedirectToAction("Index", "Salary");
            }

            TempData["ErrorMessage"] = "Salary is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SalaryDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await salaryService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Salary is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Salary is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Salary");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(SalaryRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbSalary = await salaryService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Salary is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Salary is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Salary");
        }

        [HttpPost]
        public async Task<IActionResult> Add(SalaryAddViewModel model)
        {
            var paymentIntervals = await this.paymentIntervalService.GetAllAsDropDownAsync();
            var currencies = await this.currencyService.GetAllAsDropDownAsync();
            model.Currencies = currencies;
            model.PaymentIntervals = paymentIntervals;
            if (ModelState.IsValid)
            {
                await salaryService.AddAsync(model);
                TempData["SuccessMessage"] = "Salary is added";
                return RedirectToAction("Index", "Salary");
            }

            TempData["ErrorMessage"] = "Salary is not added. Invalid data.";

            return this.View(model);
        }
    }
}
