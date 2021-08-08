namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.ProjectStatusCategory;

    public interface IProjectStatusCategoryService
    {
        Task<ICollection<ProjectStatusCategoryViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(ProjectStatusCategoryDeleteViewModel model);

        Task<bool> EditAsync(ProjectStatusCategoryEditViewModel model);

        Task<bool> RestoreAsync(ProjectStatusCategoryRestoreViewModel model);

        Task<bool> AddAsync(ProjectStatusCategoryAddViewModel model);

        Task<ProjectStatusCategoryEditViewModel> GetAsync(int id);

        Task<ICollection<ProjectStatusCategoryDropDownViewModel>> GetAllAsDropDown();
    }
}
