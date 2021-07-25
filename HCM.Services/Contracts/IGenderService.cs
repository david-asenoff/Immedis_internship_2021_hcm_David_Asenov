namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HCM.Web.ViewModels.Gender;

    public interface IGenderService
    {
        Task<IEnumerable<GenderViewModel>> GetAllGenders();
    }
}
