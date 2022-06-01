using BLL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoleService
    {
        Task<IdentityResult> AssignUserToRole(UserRole userRole);

        Task<IEnumerable<string>> GetRoles(IdentityUser user);

        Task<IEnumerable<string>> GetRoles(string userName);

        Task<IEnumerable<IdentityRole>> GetRoles();
    }
}
