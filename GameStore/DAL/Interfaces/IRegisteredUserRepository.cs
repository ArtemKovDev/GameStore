using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRegisteredUserRepository : IRepository<RegisteredUser>
    {
        IQueryable<RegisteredUser> GetAllWithDetails();

        Task<RegisteredUser> GetByIdWithDetailsAsync(int id);
    }
}
