namespace HCM.Web.Areas.Administrator.Controllers
{
using HCM.Data.Common;
using HCM.Services.Contracts;
using HCM.Web.ViewModels.EmployeeTrainings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
  
    [Area(GlobalConstants.ManagerRoleName)]
    [Authorize(Roles = GlobalConstants.ManagerRoleName)]
    public class EmployeeTrainingsController : Controller
    {
        private readonly IEmployeeTrainingService employeeTrainingService;
        private readonly IUsersService usersService;
        private readonly ITrainingService trainingService;

        public EmployeeTrainingsController(IEmployeeTrainingService employeeTrainingService,
                                           IUsersService usersService,
                                           ITrainingService trainingService)
        {
            this.employeeTrainingService = employeeTrainingService;
            this.usersService = usersService;
            this.trainingService = trainingService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await trainingService.GetAllAsync();
            TempData["LoadingSuccessMessage"] = "Trainings are loaded";
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string trainingId)
        {
            var model = await employeeTrainingService.GetAsync(trainingId);
            TempData["SuccessMessage"] = "Participants for this training are loaded";
            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string trainingId, string employeeId)
        {
            if (ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                await employeeTrainingService.DeleteAsync(trainingId, employeeId);
                TempData["SuccessMessage"] = "Employee was removed from this training";
                return RedirectToAction("Update", "EmployeeTrainings", new { trainingId = trainingId });
            }

            TempData["ErrorMessage"] = "Employee is not removed frmo the training. Invalid data.";
            return this.View(trainingId);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string trainingId, string employeeId)
        {
            var model = await employeeTrainingService.AddAsync(trainingId, employeeId);
            TempData["SuccessMessage"] = "Participant is added";
            return RedirectToAction("Update", "EmployeeTrainings", new { trainingId = trainingId });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeTrainingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dbTraining = await trainingService.EditAsync(model.Training);
                TempData["SuccessMessage"] = "Training is edited";
            }
            else
            {
                TempData["ErrorMessage"] = "Training is not edited. Invalid data.";
            }
            TempData.Keep();
            return RedirectToAction("Update", "EmployeeTrainings", new { trainingId = model.Training.Id });
        }

    }
}
