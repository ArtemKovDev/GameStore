using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GameGenreRepository
        : BaseRepository<GameGenre>, IGameGenreRepository
    {
        public GameGenreRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<GameGenre> GetAllWithDetails()
        {
            return FindAll().Include(g => g.Game).Include(g => g.Genre);
        }

        public async Task<GameGenre> GetByIdWithDetailsAsync(int id)
        {
            var gameGenres = GetAllWithDetails();
            return await gameGenres.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
