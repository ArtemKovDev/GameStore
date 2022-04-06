using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGameGenreRepository : IRepository<GameGenre>
    {
        IQueryable<GameGenre> GetAllWithDetails();

        Task<GameGenre> GetByIdWithDetailsAsync(int id);
    }
}
