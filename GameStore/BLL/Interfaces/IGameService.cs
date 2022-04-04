using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGameService
    {
        IEnumerable<GameDto> GetAll();

        Task<GameDto> GetByIdAsync(int id);

        Task AddAsync(GameDto model);

        Task UpdateAsync(GameDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
