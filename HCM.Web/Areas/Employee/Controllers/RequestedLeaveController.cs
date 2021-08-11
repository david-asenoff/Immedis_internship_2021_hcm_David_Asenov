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
    public class RequestedLeaveController : Controller
    {
        private readonly IRequestedLeavesService requestedLeavesService;
        private readonly IUsersService usersService;

        public RequestedLeaveController(IRequestedLeavesService requestedLeavesService, IUsersService usersService)
        {
            this.requestedLeavesService = requestedLeavesService;
            this.usersService = usersService;
        }
        public async Task<IActionResult> Index()
        {
            string username = this.User.Identity.Name;
            var result = await requestedLeavesService.GetAllAsync(username);
            TempData["LoadingSuccessMessage"] = "Requested Leaves are loaded";
            return View(result);
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
            string username = this.User.Identity.Name;
            var model = await requestedLeavesService.GetAsync(id,username);
            TempData["SuccessMessage"] = "Requested Leave is loaded";

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(RequestedLeaveEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                await requestedLeavesService.EditAsync(model,username);
                TempData["SuccessMessage"] = "Requested Leave is edited";
                return RedirectToAction("Index", "RequestedLeave");
            }

            TempData["ErrorMessage"] = "Requested Leave is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RequestedLeaveDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                var dbRequestedLeaves = await requestedLeavesService.DeleteAsync(model, username);
                TempData["SuccessMessage"] = "Requested Leave is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "RequestedLeave is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "RequestedLeave");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(RequestedLeaveRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                var dbRequestedLeaves = await requestedLeavesService.RestoreAsync(model, username);
                TempData["SuccessMessage"] = "Requeste dLeaves is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Requested Leave is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "RequestedLeave");
        }

        [HttpPost]
        public async Task<IActionResult> Add(RequestedLeaveAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                await requestedLeavesService.AddAsync(model, username);
                TempData["SuccessMessage"] = "RequestedLeaves is added";
                return RedirectToAction("Index", "RequestedLeave");
            }

            TempData["ErrorMessage"] = "RequestedLeaves is not added. Invalid data.";

            return this.View(model);
        }
    }
}
