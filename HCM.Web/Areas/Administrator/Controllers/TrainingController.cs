using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Training;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class TrainingController : Controller
    {
        private readonly ITrainingService trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            this.trainingService = trainingService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await trainingService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Trainings are loaded";
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TrainingEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbTraining = await trainingService.EditAsync(model);
                TempData["SuccessMessage"] = "Training is edited";
            }
            else
            {
                TempData["ErrorMessage"] = "Training is not edited. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Training");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TrainingDeleteViewModel model)
        {
            if (ModelState.IsValid)
            { 
                var dbTraining = await trainingService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Training is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Training is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Training");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(TrainingRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbTraining = await trainingService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Training is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Training is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Training");
        }

        [HttpPost]
        public async Task<IActionResult> Add(TrainingAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbTraining = await trainingService.AddAsync(model);
                TempData["SuccessMessage"] = "Training is added";
            }
            else
            {
                TempData["ErrorMessage"] = "Training is not added. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Training");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            var model = await trainingService.GetAsync(id);
            TempData["SuccessMessage"] = "Training is loaded";

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return this.View();
        }
    }
}
