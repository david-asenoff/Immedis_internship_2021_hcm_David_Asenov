namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Address;

    public interface IAddressService
    {
        Task<ICollection<AddressViewModel>> GetAllAsync();

        Task<bool> EditAsync(AddressEditViewModel model);

        Task<bool> DeleteAsync(AddressDeleteViewModel model);

        Task<bool> RestoreAsync(AddressRestoreViewModel model);

        Task<bool> AddAsync(AddressAddViewModel model);

        Task<AddressEditViewModel> GetAsync(string id);

        Task<ICollection<AddressDropDownViewModel>> GetAllAsDropDownAsync(bool getDeleted = false);
    }
}
