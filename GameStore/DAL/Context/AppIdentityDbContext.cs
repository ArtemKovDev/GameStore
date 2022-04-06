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
            
            string adminId = Guid.NewGuid().ToString();

            string userRoleId = Guid.NewGuid().ToString();           
            string managerRoleId = Guid.NewGuid().ToString();          
            string adminRoleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    Name = "user",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = managerRoleId,
                    Name = "manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            });

            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = adminId,
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123$"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                }
            });
        }
    }
}
