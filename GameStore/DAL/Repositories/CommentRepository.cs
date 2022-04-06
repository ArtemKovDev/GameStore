using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CommentRepository
        : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<Comment> GetAllWithDetails()
        {
            return FindAll().Include(c => c.RegisteredUser).Include(c => c.Game);
        }

        public async Task<Comment> GetByIdWithDetailsAsync(int id)
        {
            var comments = GetAllWithDetails();
            return await comments.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
