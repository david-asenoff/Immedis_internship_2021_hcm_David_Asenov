namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Department;

    public interface IDepartmentService
    {
        Task<ICollection<DepartmentViewModel>> GetAllAsync();

        Task<bool> EditAsync(DepartmentEditViewModel model);

        Task<bool> DeleteAsync(DepartmentDeleteViewModel model);

        Task<bool> RestoreAsync(DepartmentRestoreViewModel model);

        Task<bool> AddAsync(DepartmentAddViewModel model);

        Task<DepartmentEditViewModel> GetAsync(string id);
    }
}
