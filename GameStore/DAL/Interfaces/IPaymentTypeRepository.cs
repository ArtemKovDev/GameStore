using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPaymentTypeRepository : IRepository<PaymentType>
    {
        IQueryable<PaymentType> GetAllWithDetails();

        Task<PaymentType> GetByIdWithDetailsAsync(int id);
    }
}
