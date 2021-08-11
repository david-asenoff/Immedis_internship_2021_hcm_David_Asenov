namespace HCM.Web.Areas.Administrator.Controllers
{
    using System.Threading.Tasks;
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Position;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;


    [Area(GlobalConstants.AdministratorRoleName)]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class PositionController : Controller
    {
        private readonly IPositionService positionService;

        public PositionController(IPositionService positionService)
        {
            this.positionService = positionService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await positionService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Positions are loaded";
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

            var model = await positionService.GetAsync(id);
            TempData["SuccessMessage"] = "Position is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PositionEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await positionService.EditAsync(model);
                TempData["SuccessMessage"] = "Position is edited";
                return RedirectToAction("Index", "Position");
            }

            TempData["ErrorMessage"] = "Position is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PositionDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await positionService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Position is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Position is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Position");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(PositionRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbPosition = await positionService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Position is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Position is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Position");
        }

        [HttpPost]
        public async Task<IActionResult> Add(PositionAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await positionService.AddAsync(model);
                TempData["SuccessMessage"] = "Position is added";
                return RedirectToAction("Index", "Position");
            }

            TempData["ErrorMessage"] = "Position is not added. Invalid data.";

            return this.View(model);
        }
    }
}
