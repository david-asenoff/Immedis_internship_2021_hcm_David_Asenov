using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.EvaluationScore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class EvaluationScoreController : Controller
    {
        private readonly IEvaluationScoreService evaluationScoreService;

        public EvaluationScoreController(IEvaluationScoreService evaluationScoreService)
        {
            this.evaluationScoreService = evaluationScoreService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await evaluationScoreService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Evaluation scores are loaded";
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

            var model = await evaluationScoreService.GetAsync(id);
            TempData["SuccessMessage"] = "Evaluation scores is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EvaluationScoreEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await evaluationScoreService.EditAsync(model);
                TempData["SuccessMessage"] = "Evaluation Score is edited";
                return RedirectToAction("Index", "EvaluationScore");
            }

            TempData["ErrorMessage"] = "EvaluationScore is not edited. Invalid data.";
            return this.View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EvaluationScoreDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await evaluationScoreService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Evaluation Score is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Evaluation Score is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "EvaluationScore");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(EvaluationScoreRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbEvaluationScore = await evaluationScoreService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Evaluation Score is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Evaluation Score is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "EvaluationScore");
        }

        [HttpPost]
        public async Task<IActionResult> Add(EvaluationScoreAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await evaluationScoreService.AddAsync(model);
                TempData["SuccessMessage"] = "Evaluation Score is added";
                return RedirectToAction("Index", "EvaluationScore");
            }

            TempData["ErrorMessage"] = "EvaluationScore is not added. Invalid data.";

            return this.View(model);
        }
    }
}
