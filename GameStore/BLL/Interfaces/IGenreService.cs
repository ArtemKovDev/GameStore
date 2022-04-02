using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<GenreDto> GetAll();

        Task<GenreDto> GetByIdAsync(int id);

        Task AddAsync(GenreDto model);

        Task UpdateAsync(GenreDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
