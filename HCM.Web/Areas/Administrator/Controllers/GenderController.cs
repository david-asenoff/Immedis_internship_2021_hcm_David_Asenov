using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Gender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class GenderController : Controller
    {
        private readonly IGenderService genderService;

        public GenderController(IGenderService genderService)
        {
            this.genderService = genderService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await genderService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Genders are loaded";
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

            var model = await genderService.GetAsync(id);
            TempData["SuccessMessage"] = "Gender is loaded";

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(GenderEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await genderService.EditAsync(model);
                TempData["SuccessMessage"] = "Gender is edited";
                return RedirectToAction("Index", "Gender");
            }

            TempData["ErrorMessage"] = "Gender is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(GenderDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbGender = await genderService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Gender is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Gender is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Gender");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(GenderRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbGender = await genderService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Gender is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Gender is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Gender");
        }

        [HttpPost]
        public async Task<IActionResult> Add(GenderAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await genderService.AddAsync(model);
                TempData["SuccessMessage"] = "Gender is added";
                return RedirectToAction("Index", "Gender");
            }

            TempData["ErrorMessage"] = "Gender is not added. Invalid data.";

            return this.View(model);
        }
    }
}
