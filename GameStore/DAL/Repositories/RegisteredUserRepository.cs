﻿using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class RegisteredUserRepository
        : BaseRepository<RegisteredUser>, IRegisteredUserRepository
    {
        public RegisteredUserRepository(DbContext context) 
            : base(context)
        {

        }

        public IQueryable<RegisteredUser> GetAllWithDetails()
        {
            return FindAll().Include(r => r.Comments);
        }

        public async Task<RegisteredUser> GetByIdWithDetailsAsync(int id)
        {
            var registeredUsers = GetAllWithDetails();
            return await registeredUsers.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}