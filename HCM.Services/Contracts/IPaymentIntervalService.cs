namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.PaymentInterval;

    public interface IPaymentIntervalService
    {
        Task<ICollection<PaymentIntervalViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(PaymentIntervalDeleteViewModel model);

        Task<bool> EditAsync(PaymentIntervalEditViewModel model);

        Task<bool> RestoreAsync(PaymentIntervalRestoreViewModel model);

        Task<bool> AddAsync(PaymentIntervalAddViewModel model);

        Task<PaymentIntervalEditViewModel> GetAsync(int id);

        Task<ICollection<PaymentIntervalDropDownViewModel>> GetAllAsDropDownAsync();
    }
}
