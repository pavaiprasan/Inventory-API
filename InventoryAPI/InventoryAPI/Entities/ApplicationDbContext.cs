using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;

namespace InventoryAPI.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
                   optionsBuilder.UseNpgsql("server=localhost;user Id=postgres;Password=admin;Database=Inventory");
    }
}
