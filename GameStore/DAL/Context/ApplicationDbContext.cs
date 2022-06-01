using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CartLine> CartLines { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RegisteredUser>().HasData(new RegisteredUser()
            {
                Id = 1,
                UserName = "SamHyde",
                Email = "admin@gmail.com",
                FirstName = "Sam",
                LastName = "Hyde",
                ImageUrl = null
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {
                new PaymentType(){ Id = 1, Name = "Card"},
                new PaymentType(){ Id = 2, Name = "Cash"}
            });
        }
    }
}
