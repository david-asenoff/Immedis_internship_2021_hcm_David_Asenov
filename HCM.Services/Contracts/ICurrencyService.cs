namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Currency;

    public interface ICurrencyService
    {
        Task<ICollection<CurrencyViewModel>> GetAllAsync();

        Task<bool> EditAsync(CurrencyEditViewModel model);

        Task<bool> DeleteAsync(CurrencyDeleteViewModel model);

        Task<bool> RestoreAsync(CurrencyRestoreViewModel model);

        Task<bool> AddAsync(CurrencyAddViewModel model);

        Task<CurrencyEditViewModel> GetAsync(int id);
    }
}
