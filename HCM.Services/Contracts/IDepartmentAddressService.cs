namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.DepartmentAddress;

    public interface IDepartmentAddressService
    {
        Task<ICollection<DepartmentAddressViewModel>> GetAllAsync();

        Task<bool> EditAsync(DepartmentAddressEditViewModel model);

        Task<bool> DeleteAsync(DepartmentAddressDeleteViewModel model);

        Task<bool> RestoreAsync(DepartmentAddressRestoreViewModel model);

        Task<bool> AddAsync(DepartmentAddressAddViewModel model);

        Task<DepartmentAddressEditViewModel> GetAsync(string id);
    }
}
