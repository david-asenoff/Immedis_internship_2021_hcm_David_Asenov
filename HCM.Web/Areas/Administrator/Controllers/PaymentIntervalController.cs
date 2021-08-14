using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.PaymentInterval;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class PaymentIntervalController : Controller
    {
        private readonly IPaymentIntervalService paymentIntervalService;

        public PaymentIntervalController(IPaymentIntervalService paymentIntervalService)
        {
            this.paymentIntervalService = paymentIntervalService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await paymentIntervalService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Payment Intervals are loaded";
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

            var model = await paymentIntervalService.GetAsync(id);
            TempData["SuccessMessage"] = "PaymentInterval is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PaymentIntervalEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await paymentIntervalService.EditAsync(model);
                TempData["SuccessMessage"] = "PaymentInterval is edited";
                return RedirectToAction("Index", "PaymentInterval");
            }

            TempData["ErrorMessage"] = "PaymentInterval is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PaymentIntervalDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await paymentIntervalService.DeleteAsync(model);
                TempData["SuccessMessage"] = "PaymentInterval is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "PaymentInterval is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "PaymentInterval");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(PaymentIntervalRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbPaymentInterval = await paymentIntervalService.RestoreAsync(model);
                TempData["SuccessMessage"] = "PaymentInterval is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "PaymentInterval is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "PaymentInterval");
        }

        [HttpPost]
        public async Task<IActionResult> Add(PaymentIntervalAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await paymentIntervalService.AddAsync(model);
                TempData["SuccessMessage"] = "PaymentInterval is added";
                return RedirectToAction("Index", "PaymentInterval");
            }

            TempData["ErrorMessage"] = "PaymentInterval is not added. Invalid data.";

            return this.View(model);
        }
    }
}
