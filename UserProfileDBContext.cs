using Microsoft.EntityFrameworkCore;
using ShopApi.models;

namespace ShopApi
{
    public class UserProfileDBContext : DbContext
    {
        public UserProfileDBContext(DbContextOptions<UserProfileDBContext> options) : base(options)
        {
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<UserProfile>()
                .ToTable("UserProfileDb");
        }*/
        public DbSet<UserProfileDb> UserProfileDbs { get; set; }
    }
}
