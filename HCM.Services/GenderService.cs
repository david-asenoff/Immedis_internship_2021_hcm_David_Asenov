namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Web.ViewModels.Gender;
    using Microsoft.EntityFrameworkCore;

    public class GenderService : IGenderService
    {
        private readonly ApplicationDbContext db;

        public GenderService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<GenderViewModel>> GetAllGenders()
        {
            var result = await this.db.Genders.Select(x => new GenderViewModel
            {
                Id = x.Id,
                Type = x.Type,
            }).ToListAsync();

            return result;
        }
    }
}