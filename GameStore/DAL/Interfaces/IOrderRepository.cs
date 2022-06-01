using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllWithDetails();

        Task<Order> GetByIdWithDetailsAsync(int id);
    }
}
