using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRegisteredUserService
    {
        IEnumerable<RegisteredUserDto> GetAll();

        Task<RegisteredUserDto> GetByIdAsync(int id);

        Task AddAsync(RegisteredUserDto model);

        Task UpdateAsync(RegisteredUserDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
