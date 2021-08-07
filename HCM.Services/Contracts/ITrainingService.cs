namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Training;

    public interface ITrainingService
    {
        Task<ICollection<TrainingViewModel>> GetAllAsync();

        Task<bool> EditAsync(TrainingEditViewModel model);

        Task<bool> DeleteAsync(TrainingDeleteViewModel model);

        Task<bool> RestoreAsync(TrainingRestoreViewModel model);

        Task<bool> AddAsync(TrainingAddViewModel model);

        Task<TrainingEditViewModel> GetAsync(string id);
    }
}
