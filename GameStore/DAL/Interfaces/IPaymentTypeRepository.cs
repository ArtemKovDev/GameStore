using DAL.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPaymentTypeRepository : IRepository<PaymentType>
    {
        IQueryable<PaymentType> GetAllWithDetails();

        Task<PaymentType> GetByIdWithDetailsAsync(int id);
    }
}
