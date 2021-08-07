namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.EvaluationScore;

    public interface IEvaluationScoreService
    {
        Task<ICollection<EvaluationScoreViewModel>> GetAllAsync();

        Task<bool> EditAsync(EvaluationScoreEditViewModel model);

        Task<bool> DeleteAsync(EvaluationScoreDeleteViewModel model);

        Task<bool> RestoreAsync(EvaluationScoreRestoreViewModel model);

        Task<bool> AddAsync(EvaluationScoreAddViewModel model);

        Task<EvaluationScoreEditViewModel> GetAsync(int id);
    }
}
