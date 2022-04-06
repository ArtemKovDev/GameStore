using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICartLineRepository : IRepository<CartLine>
    {
        IQueryable<CartLine> GetAllWithDetails();

        Task<CartLine> GetByIdWithDetailsAsync(int id);
    }
}
