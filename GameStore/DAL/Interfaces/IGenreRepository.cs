using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenreRepository : IRepository<Genre>
    {
        IQueryable<Genre> GetAllWithDetails();

        Task<Genre> GetByIdWithDetailsAsync(int id);
    }
}
