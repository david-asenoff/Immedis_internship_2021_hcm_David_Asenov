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
    public class EmployeeContractController : Controller
    {
        private readonly IRequestedLeavesService requestedLeavesService;
        private readonly IUsersService usersService;
        private readonly IEmployeeContractService employeeContractService;

        public EmployeeContractController(IRequestedLeavesService requestedLeavesService, IUsersService usersService, IEmployeeContractService employeeContractService)
        {
            this.requestedLeavesService = requestedLeavesService;
            this.usersService = usersService;
            this.employeeContractService = employeeContractService;
        }
        public async Task<IActionResult> Index()
        {
            string username = this.User.Identity.Name;
            var result = await employeeContractService.GetAllByEmployeeUsernameAsync(username);
            TempData["LoadingSuccessMessage"] = "Contracts are loaded";
            return View(result);
        }
    }
}
