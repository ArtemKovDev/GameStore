using BLL.Interfaces;
using BLL.Models.Identity;
using BLL.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AssignUserToRole(UserRole userRole)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userRole.UserName);

            if (user is null)
            {
                throw new ServiceException(string.Join(';', "This user does not exist"));
            }

            var userRoles = await GetRoles(user);

            if (userRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, userRoles.ToArray());
            }   

            var isRoleExist = _roleManager.Roles.Select(r => r.Name).ToList().Contains(userRole.Role, StringComparer.OrdinalIgnoreCase);

            if (!isRoleExist)
            {
                throw new ServiceException(string.Join(';', "This user role does not exist"));
            }

            var result = await _userManager.AddToRoleAsync(user, userRole.Role.ToUpper());

            return result;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetRoles(IdentityUser user)
        {
            return (await _userManager.GetRolesAsync(user)).ToList();
        }

        public async Task<IEnumerable<string>> GetRoles(string userName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userName);

            return (await _userManager.GetRolesAsync(user)).ToList();
        }
    }
}
