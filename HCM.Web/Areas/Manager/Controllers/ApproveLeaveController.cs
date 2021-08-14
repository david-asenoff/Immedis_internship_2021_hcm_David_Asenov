namespace HCM.Web.Areas.Administrator.Controllers
{
using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.ApproveLeave;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

    [Area(GlobalConstants.ManagerRoleName)]
    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class ApproveLeaveController : Controller
    {
        private readonly IApproveLeaveService approveLeaveService;
        private readonly IUsersService usersService;

        public ApproveLeaveController(IApproveLeaveService approveLeaveService, IUsersService usersService)
        {
            this.approveLeaveService = approveLeaveService;
            this.usersService = usersService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await approveLeaveService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Requested Leaves are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            string username = this.User.Identity.Name;
            var model = await approveLeaveService.GetAsync(id);
            TempData["SuccessMessage"] = "Requested Leave is loaded";

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ApproveLeaveEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                await approveLeaveService.EditAsync(model, username);
                TempData["SuccessMessage"] = "Requested Leave is edited";
                return RedirectToAction("Index", "ApproveLeave");
            }

            TempData["ErrorMessage"] = "Requested Leave is not edited. Invalid data.";
            return this.View(model);
        }

    }
}
