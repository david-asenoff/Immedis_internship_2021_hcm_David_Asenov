namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.EmployeeContract;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area(GlobalConstants.ManagerRoleName)]
    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class EmployeeContractController : Controller
    {
        private readonly IEmployeeContractService employeeContractService;
        private readonly IUsersService usersService;
        private readonly IDepartmentService departmentService;
        private readonly IPositionService positionService;
        private readonly IPaymentIntervalService paymentInterval;
        private readonly ICurrencyService currencyService;

        public EmployeeContractController(IEmployeeContractService employeeContractService, 
                                          IUsersService usersService, 
                                          IDepartmentService departmentService, 
                                          IPositionService positionService,
                                          IPaymentIntervalService paymentInterval,
                                          ICurrencyService currencyService)
        {
            this.employeeContractService = employeeContractService;
            this.usersService = usersService;
            this.departmentService = departmentService;
            this.positionService = positionService;
            this.paymentInterval = paymentInterval;
            this.currencyService = currencyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await employeeContractService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Contracts are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string contractId)
        {
            var model = await employeeContractService.GetAsync(contractId);
            model.Departments = await departmentService.GetAllAsDropDownAsync();
            model.Positions = await positionService.GetAllAsDropDownAsync();
            model.Salary.PaymentIntervals = await paymentInterval.GetAllAsDropDownAsync();
            model.Salary.Currencies = await currencyService.GetAllAsDropDownAsync();
            TempData["SuccessMessage"] = "Contract is loaded";

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeContractViewModel model)
        {
            if (ModelState.IsValid)
            {
                    await employeeContractService.EditAsync(model);
                    TempData["SuccessMessage"] = "Contract is edited";
                    return RedirectToAction("Index", "EmployeeContract");
                
            }

            TempData["ErrorMessage"] = "Contract is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EndTheContract(string contractId)
        {
            if (ModelState.IsValid)
            {
                await employeeContractService.EndTheContractAsync(contractId);
                TempData["SuccessMessage"] = "Contract has successfuly ended";
                return RedirectToAction("Index", "EmployeeContract");
            }

            TempData["ErrorMessage"] = "Contract cannot be ended. Invalid data.";
            return RedirectToAction("Index", "EmployeeContract");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var viewModel = new EmployeeContractAddViewModel();
            viewModel.Employees = await this.usersService.GetAllAsDropDownAsync();
            viewModel.Departments = await departmentService.GetAllAsDropDownAsync();
            viewModel.Positions = await positionService.GetAllAsDropDownAsync();
            viewModel.Salary.PaymentIntervals = await paymentInterval.GetAllAsDropDownAsync();
            viewModel.Salary.Currencies = await currencyService.GetAllAsDropDownAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeContractAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await employeeContractService.CreateAsync(model);
                TempData["SuccessMessage"] = "Contract is added";
                return RedirectToAction("Index", "EmployeeContract");
            }

            TempData["ErrorMessage"] = "Contract is not added. Invalid data.";

            return this.View(model);
        }

    }
}
