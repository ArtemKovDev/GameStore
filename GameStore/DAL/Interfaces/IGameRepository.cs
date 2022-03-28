using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        IQueryable<Game> GetAllWithDetails();

        Task<Game> GetByIdWithDetailsAsync(int id);
    }
}
