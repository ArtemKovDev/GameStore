using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IPaymentTypeService
    {
        IEnumerable<PaymentTypeDto> GetAll();

        Task<PaymentTypeDto> GetByIdAsync(int id);

        Task AddAsync(PaymentTypeDto model);

        Task UpdateAsync(PaymentTypeDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
