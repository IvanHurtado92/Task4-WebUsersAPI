using Microsoft.EntityFrameworkCore;

namespace Task4_WebUsersAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<User> Users { get; set; }
    }
}
