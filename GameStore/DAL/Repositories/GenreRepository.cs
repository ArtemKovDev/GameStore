using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenreRepository
        : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<Genre> GetAllWithDetails()
        {
            return FindAll().Include(g => g.Games);
        }

        public async Task<Genre> GetByIdWithDetailsAsync(int id)
        {
            var genres = GetAllWithDetails();
            return await genres.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
