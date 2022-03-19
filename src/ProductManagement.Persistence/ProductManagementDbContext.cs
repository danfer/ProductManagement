using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Persistence
{
    public class ProductManagementDbContext : DbContext
    {
        public ProductManagementDbContext(DbContextOptions<ProductManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 10, ProductName = "Cheese", CategoryId = 33, CategoryName = "Dairy", Quantity = 100 },
                    new Product { ProductId = 12, ProductName = "Milk", CategoryId = 33, CategoryName = "Dairy", Quantity = 233 },
                    new Product { ProductId = 13, ProductName = "Tomatoes", CategoryId = 15, CategoryName = "Vegetables", Quantity = 133 },
                    new Product { ProductId = 14, ProductName = "Carrot", CategoryId = 15, CategoryName = "Vegetables", Quantity = 221 },
                    new Product { ProductId = 15, ProductName = "Onion", CategoryId = 15, CategoryName = "Vegetables", Quantity = 0 }
                );
        }
    }
}
