using BLL.Interfaces;
using BLL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(Register user)
        {
            var result = await _userManager.CreateAsync(new IdentityUser
            {
                Email = user.UserName,
                UserName = user.UserName,
            }, user.Password);

            return result;
        }

        public async Task<IdentityUser> Logon(Logon logon)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == logon.UserName);

            return await _userManager.CheckPasswordAsync(user, logon.Password) ? user : null;
        }
    }
}
