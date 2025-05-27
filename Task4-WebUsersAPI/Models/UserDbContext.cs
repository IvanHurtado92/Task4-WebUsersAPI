using Microsoft.EntityFrameworkCore;

namespace Task4_WebUsersAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) 
            : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u=>u.Email).IsUnique(); // Email tendrá índice único
        }

        public DbSet<User> Users { get; set; }
    }
}
