using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace HCM.Web.Areas.Administrator.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorAndManagerRoleName)]
    public class AddressController : Controller
    {
        private readonly IAddressService addressService;
        private readonly IConfiguration config;

        public AddressController(IAddressService addressService,
                                 IConfiguration config)
        {
            this.addressService = addressService;
            this.config = config;
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
            var googlePlacesApiKey = config.GetValue<string>("GooglePlacesApiKey").ToString();
            TempData["GooglePlacesApiKey"] = googlePlacesApiKey;
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var googlePlacesApiKey = config.GetValue<string>("GooglePlacesApiKey").ToString();
            TempData["GooglePlacesApiKey"] = googlePlacesApiKey;
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
