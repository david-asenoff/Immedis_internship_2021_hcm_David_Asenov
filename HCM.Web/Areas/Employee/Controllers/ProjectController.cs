using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.RequestedLeave;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Employee.Controllers
{
    [Area(GlobalConstants.EmployeeRoleName)]
    [Authorize(Roles = GlobalConstants.EmployeeRoleName)]
    public class ProjectController : Controller
    {
        private readonly IRequestedLeavesService requestedLeavesService;
        private readonly IUsersService usersService;
        private readonly IProjectService projectService;

        public ProjectController(IRequestedLeavesService requestedLeavesService, IUsersService usersService, IProjectService projectService)
        {
            this.requestedLeavesService = requestedLeavesService;
            this.usersService = usersService;
            this.projectService = projectService;
        }
        public async Task<IActionResult> Index()
        {
            string username = this.User.Identity.Name;
            var result = await projectService.GetAllByUsernameAsync(username);
            TempData["LoadingSuccessMessage"] = "Projects are loaded";
            return View(result);
        }
    }
}
