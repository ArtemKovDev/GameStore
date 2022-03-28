using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRegisteredUserRepository : IRepository<RegisteredUser>
    {
        IQueryable<RegisteredUser> GetAllWithDetails();

        Task<RegisteredUser> GetByIdWithDetailsAsync(int id);
    }
}
