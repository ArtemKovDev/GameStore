using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGameGenreService
    {
        IEnumerable<GameGenreDto> GetAll();

        Task<GameGenreDto> GetByIdAsync(int id);

        Task AddAsync(GameGenreDto model);

        Task UpdateAsync(GameGenreDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
