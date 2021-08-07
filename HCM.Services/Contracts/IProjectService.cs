namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Project;

    public interface IProjectService
    {
        Task<ICollection<ProjectViewModel>> GetAllAsync();

        Task<bool> EditAsync(ProjectEditViewModel model);

        Task<bool> DeleteAsync(ProjectDeleteViewModel model);

        Task<bool> RestoreAsync(ProjectRestoreViewModel model);

        Task<bool> AddAsync(ProjectAddViewModel model);

        Task<ProjectEditViewModel> GetAsync(string id);
    }
}
