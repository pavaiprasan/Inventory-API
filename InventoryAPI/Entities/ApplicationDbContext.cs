using Microsoft.EntityFrameworkCore;
using InventoryAPI.Models;
using System.Collections.Generic;


namespace InventoryAPI.Entity
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<SubMenu> SubMenu { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseProducts> PurchaseProducts { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SalesProducts> SalesProducts { get; set; }
        public DbSet<SalesPayment> SalesPayment { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);           
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
                   optionsBuilder.UseNpgsql("server=localhost;user Id=postgres;Password=admin;Database=Inventory");
    }
}
