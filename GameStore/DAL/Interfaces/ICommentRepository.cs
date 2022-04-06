using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<Comment> GetAllWithDetails();

        Task<Comment> GetByIdWithDetailsAsync(int id);
    }
}
