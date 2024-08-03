using Microsoft.EntityFrameworkCore;
using CustomerPortalAPI2.Models;

namespace CustomerPortalAPI2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("portalKAG_Users").HasIndex(u => u.Username).IsUnique();
        }
    }
}
