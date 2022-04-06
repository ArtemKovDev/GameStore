using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentDto> GetAll();

        Task<CommentDto> GetByIdAsync(int id);

        Task AddAsync(CommentDto model);

        Task UpdateAsync(CommentDto model);

        Task DeleteByIdAsync(int modelId);
    }
}
