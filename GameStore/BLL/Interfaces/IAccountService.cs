using BLL.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(Register user);

        Task<IdentityUser> Logon(Logon logon);
    }
}
