using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAll();

        Task<OrderDto> GetByIdAsync(int id);

        Task AddAsync(OrderDto model);

        Task UpdateAsync(OrderDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
