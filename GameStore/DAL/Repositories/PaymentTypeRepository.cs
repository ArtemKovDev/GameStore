using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PaymentTypeRepository
        : BaseRepository<PaymentType>, IPaymentTypeRepository
    {
        public PaymentTypeRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public IQueryable<PaymentType> GetAllWithDetails()
        {
            return FindAll().Include(p => p.Orders);
        }

        public async Task<PaymentType> GetByIdWithDetailsAsync(int id)
        {
            var paymentTypes = GetAllWithDetails();
            return await paymentTypes.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
