using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GameRepository
        : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DbContext context) 
            : base(context)
        {

        }

        public IQueryable<Game> GetAllWithDetails()
        {
            return FindAll().Include(g => g.Genres).Include(g => g.Comments).Include(g => g.CartLines);
        }

        public async Task<Game> GetByIdWithDetailsAsync(int id)
        {
            var games = GetAllWithDetails();
            return await games.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
