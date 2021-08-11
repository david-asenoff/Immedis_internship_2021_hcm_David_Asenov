namespace HCM.Services.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HCM.Data;
    using HCM.Web.ViewModels.Role;
    using Microsoft.EntityFrameworkCore;

    public class RoleService : IRoleService
    {
        private readonly ApplicationDbContext db;

        public RoleService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<ICollection<RoleDropDownViewModel>> GetAllAsDropDownAsync()
        {
            var roles = await this.db.IdentityRoles.Select(x => new RoleDropDownViewModel
            {
                Id = x.Id,
                Type = x.Type,
            }).ToListAsync();

            return roles;
        }
    }
}