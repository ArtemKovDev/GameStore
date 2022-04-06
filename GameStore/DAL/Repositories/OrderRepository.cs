using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository
        : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<Order> GetAllWithDetails()
        {
            return FindAll().Include(o => o.PaymentType).Include(o => o.CartLines);
        }

        public async Task<Order> GetByIdWithDetailsAsync(int id)
        {
            var orders = GetAllWithDetails();
            return await orders.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
