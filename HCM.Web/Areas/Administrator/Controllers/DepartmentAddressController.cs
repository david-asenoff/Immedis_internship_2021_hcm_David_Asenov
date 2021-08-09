namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.DepartmentAddress;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class DepartmentAddressController : Controller
    {
        private readonly IDepartmentAddressService departmentAddressService;
        private readonly IAddressService addressService;
        private readonly IDepartmentService departmentService;
        private readonly ICompanyService companyService;

        public DepartmentAddressController(
            IDepartmentAddressService departmentAddressService,
            IAddressService addressService,
            IDepartmentService departmentService,
            ICompanyService companyService)
        {
            this.departmentAddressService = departmentAddressService;
            this.addressService = addressService;
            this.departmentService = departmentService;
            this.companyService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await departmentAddressService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Department Addresses are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var departments = await this.departmentService.GetAllAsDropDownAsync();
            var addresses = await this.addressService.GetAllAsDropDownAsync();
            var viewModel = new DepartmentAddressAddViewModel
            {
                Departments = departments,
                Addresses = addresses,
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var departments = await this.departmentService.GetAllAsDropDownAsync();
            var addresses = await this.addressService.GetAllAsDropDownAsync();
            var model = await departmentAddressService.GetAsync(id);
            model.Departments = departments;
            model.Addresses = addresses;
            TempData["SuccessMessage"] = "Department Address is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentAddressEditViewModel model)
        {
            var departments = await this.departmentService.GetAllAsDropDownAsync();
            var addresses = await this.addressService.GetAllAsDropDownAsync();
            model.Departments = departments;
            model.Addresses = addresses;
            if (ModelState.IsValid)
            {
                await departmentAddressService.EditAsync(model);
                TempData["SuccessMessage"] = "Department Address is edited";
                return RedirectToAction("Index", "DepartmentAddress");
            }

            TempData["ErrorMessage"] = "Department Address is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentAddressDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await departmentAddressService.DeleteAsync(model);
                TempData["SuccessMessage"] = "DepartmentAddress is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "DepartmentAddress is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "DepartmentAddress");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(DepartmentAddressRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbDepartmentAddress = await departmentAddressService.RestoreAsync(model);
                TempData["SuccessMessage"] = "DepartmentAddress is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "DepartmentAddress is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "DepartmentAddress");
        }

        [HttpPost]
        public async Task<IActionResult> Add(DepartmentAddressAddViewModel model)
        {
            var departments = await this.departmentService.GetAllAsDropDownAsync();
            var addresses = await this.addressService.GetAllAsDropDownAsync();
            model.Departments = departments;
            model.Addresses = addresses;
            if (ModelState.IsValid)
            {
                await departmentAddressService.AddAsync(model);
                TempData["SuccessMessage"] = "DepartmentAddress is added";
                return RedirectToAction("Index", "DepartmentAddress");
            }

            TempData["ErrorMessage"] = "DepartmentAddress is not added. Invalid data.";

            return this.View(model);
        }
    }
}
