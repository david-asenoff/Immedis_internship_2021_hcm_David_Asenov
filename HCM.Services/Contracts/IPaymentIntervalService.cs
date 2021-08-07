namespace HCM.Services.Contracts
{
    using HCM.Web.ViewModels.Company;
    using HCM.Web.ViewModels.PaymentInterval;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPaymentIntervalService
    {
        Task<ICollection<PaymentIntervalViewModel>> GetAllAsync();

        Task<bool> DeleteAsync(PaymentIntervalDeleteViewModel model);

        Task<bool> EditAsync(PaymentIntervalEditViewModel model);

        Task<bool> RestoreAsync(PaymentIntervalRestoreViewModel model);

        Task<bool> AddAsync(PaymentIntervalAddViewModel model);

        Task<PaymentIntervalEditViewModel> GetAsync(int id);

        ICollection<PaymentIntervalDropDownViewModel> GetPaymentIntervalsAsDropDown();
    }
}
