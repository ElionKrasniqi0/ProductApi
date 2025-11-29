using Microsoft.EntityFrameworkCore;
using ProductApi.Entities;

namespace ProductApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed initial data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 999.99m, StockQuantity = 10, CreatedAt = DateTime.UtcNow },
                new Product { Id = 2, Name = "Book", Category = "Education", Price = 29.99m, StockQuantity = 100, CreatedAt = DateTime.UtcNow },
                new Product { Id = 3, Name = "Mouse", Category = "Electronics", Price = 49.99m, StockQuantity = 0, CreatedAt = DateTime.UtcNow },
                new Product { Id = 4, Name = "Desk", Category = "Furniture", Price = 199.99m, StockQuantity = 5, CreatedAt = DateTime.UtcNow },
                new Product { Id = 5, Name = "Chair", Category = "Furniture", Price = 149.99m, StockQuantity = 8, CreatedAt = DateTime.UtcNow }
            );
        }
    }
}