using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CartLineRepository
        : BaseRepository<CartLine>, ICartLineRepository
    {
        public CartLineRepository(ApplicationDbContext context) 
            : base(context)
        {

        }

        public IQueryable<CartLine> GetAllWithDetails()
        {
            return FindAll().Include(c => c.Game).Include(c => c.Order);
        }

        public async Task<CartLine> GetByIdWithDetailsAsync(int id)
        {
            var cartLines = GetAllWithDetails();
            return await cartLines.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
