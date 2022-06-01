using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        IQueryable<Game> GetAllWithDetails();

        Task<Game> GetByIdWithDetailsAsync(int id);
    }
}
