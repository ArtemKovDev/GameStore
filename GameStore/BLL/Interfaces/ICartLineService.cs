using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICartLineService
    {
        IEnumerable<CartLineDto> GetAll();

        Task<CartLineDto> GetByIdAsync(int id);

        Task AddAsync(CartLineDto model);

        Task UpdateAsync(CartLineDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
