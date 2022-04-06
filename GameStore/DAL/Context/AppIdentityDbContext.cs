using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            const string ADMIN_ROLE_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string MANAGER_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";
            const string USER_ROLE_ID = "7c9e6679-7425-40de-944b-e07fc1f90ae7";

            modelBuilder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole
                {
                    Id = USER_ROLE_ID,
                    Name = "user",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = MANAGER_ROLE_ID,
                    Name = "manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            });
        }
    }
}
