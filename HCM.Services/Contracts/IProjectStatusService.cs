namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.ProjectStatus;

    public interface IProjectStatusService
    {
        Task<ICollection<ProjectStatusViewModel>> GetAllAsync();

        Task<bool> EditAsync(ProjectStatusEditViewModel model);

        Task<bool> DeleteAsync(ProjectStatusDeleteViewModel model);

        Task<bool> RestoreAsync(ProjectStatusRestoreViewModel model);

        Task<bool> AddAsync(ProjectStatusAddViewModel model);

        Task<ProjectStatusEditViewModel> GetAsync(string id);
    }
}
