namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.RequestedLeave;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area(GlobalConstants.EmployeeRoleName)]
    [Authorize(Roles = GlobalConstants.EmployeeRoleName)]
    public class RequestedLeavesController : Controller
    {
        private readonly IRequestedLeavesService requestedLeavesService;
        private readonly IUsersService usersService;

        public RequestedLeavesController(IRequestedLeavesService requestedLeavesService, IUsersService usersService)
        {
            this.requestedLeavesService = requestedLeavesService;
            this.usersService = usersService;
        }
        public async Task<IActionResult> Index()
        {
            //var result = await requestedLeavesService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "RequestedLeaves are loaded";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            string username = this.User.Identity.Name;
            var model = new RequestedLeaveAddViewModel();
            model.Username = username;
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {

            //var model = await requestedLeavesService.GetAsync(id);
            TempData["SuccessMessage"] = "RequestedLeaves is loaded";

            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(RequestedLeaveEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                //await requestedLeavesService.EditAsync(model);
                TempData["SuccessMessage"] = "RequestedLeaves is edited";
                return RedirectToAction("Index", "RequestedLeaves");
            }

            TempData["ErrorMessage"] = "RequestedLeaves is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RequestedLeaveDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var dbRequestedLeaves = await requestedLeavesService.DeleteAsync(model);
                TempData["SuccessMessage"] = "RequestedLeaves is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "RequestedLeaves is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "RequestedLeaves");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(RequestedLeaveRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var dbRequestedLeaves = await requestedLeavesService.RestoreAsync(model);
                TempData["SuccessMessage"] = "RequestedLeaves is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "RequestedLeaves is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "RequestedLeaves");
        }

        [HttpPost]
        public async Task<IActionResult> Add(RequestedLeaveAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                //await requestedLeavesService.AddAsync(model);
                TempData["SuccessMessage"] = "RequestedLeaves is added";
                return RedirectToAction("Index", "RequestedLeaves");
            }

            TempData["ErrorMessage"] = "RequestedLeaves is not added. Invalid data.";

            return this.View(model);
        }
    }
}
