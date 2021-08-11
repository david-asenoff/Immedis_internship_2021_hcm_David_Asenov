namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Role;

    public interface IRoleService
    {
        Task<ICollection<RoleDropDownViewModel>> GetAllAsDropDownAsync();
    }
}
