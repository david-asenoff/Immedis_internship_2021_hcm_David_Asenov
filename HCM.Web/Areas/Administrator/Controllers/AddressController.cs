namespace HCM.Web.Areas.Administrator.Controllers
{
    using HCM.Data.Common;
    using HCM.Services.Contracts;
    using HCM.Web.ViewModels.Address;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Area("Administrator")]
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]

    public class AddressController : Controller
    {
        private readonly IAddressService addressService;

        public AddressController(IAddressService addressService)
        {
            this.addressService = addressService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await addressService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Addresses are loaded";
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

            var model = await addressService.GetAsync(id);
            TempData["SuccessMessage"] = "Address is loaded";

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddressEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                await addressService.EditAsync(model);
                TempData["SuccessMessage"] = "Address is edited";
                return RedirectToAction("Index", "Address");
            }

            TempData["ErrorMessage"] = "Address is not edited. Invalid data.";
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AddressDeleteViewModel model)
        {
            if (ModelState.IsValid)
            {
                await addressService.DeleteAsync(model);
                TempData["SuccessMessage"] = "Address is deleted";
            }
            else
            {
                TempData["ErrorMessage"] = "Address is not deleted. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Address");
        }

        [HttpPost]
        public async Task<IActionResult> Restore(AddressRestoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbAddress = await addressService.RestoreAsync(model);
                TempData["SuccessMessage"] = "Address is restored";
            }
            else
            {
                TempData["ErrorMessage"] = "Address is not restored. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Index", "Address");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddressAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                await addressService.AddAsync(model);
                TempData["SuccessMessage"] = "Address is added";
                return RedirectToAction("Index", "Address");
            }

            TempData["ErrorMessage"] = "Address is not added. Invalid data.";

            return this.View(model);
        }
    }
}
