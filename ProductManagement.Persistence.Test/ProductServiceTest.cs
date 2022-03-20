using Microsoft.EntityFrameworkCore;
using ProductManagement.Core.Models;
using ProductManagement.Domain;
using ProductManagement.Persistence.Repositories;
using System.Linq;
using Xunit;

namespace ProductManagement.Persistence.Test
{
    public class ProductServiceTest
    {
        [Fact]
        public void ShouldReturnProductsWithExistences()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<ProductManagementDbContext>()
                .UseInMemoryDatabase("AvailableProductsTest")
                .Options;
            using var context = new ProductManagementDbContext(dbOptions);
            context.Add(new Product { ProductId = 1, ProductName = "Cheese", CategoryId = 33, CategoryName = "Dairy", Quantity = 100 });
            context.Add(new Product { ProductId = 2, ProductName = "Carrot", CategoryId = 15, CategoryName = "Vegetables", Quantity = 221 });
            context.Add(new Product { ProductId = 3, ProductName = "Onion", CategoryId = 15, CategoryName = "Vegetables", Quantity = 0 });
            context.SaveChanges();
            var productService = new ProductService(context);
            //Act
            var availableProducts = productService.GetAvailableProducts();

            //Assert
            Assert.Equal(2, availableProducts.Count());
            Assert.Contains(availableProducts, p => p.ProductId == 1);
            Assert.Contains(availableProducts, p => p.ProductId == 2);
            Assert.DoesNotContain(availableProducts, p => p.ProductId == 3);
        }

        [Fact]
        public void ShouldBeAbleToAddProduct()
        {
            //Arrange
            var dbOptions = new DbContextOptionsBuilder<ProductManagementDbContext>()
                .UseInMemoryDatabase("ShouldSaveProductTest")
                .Options;
            using var context = new ProductManagementDbContext(dbOptions);

            context.SaveChanges();
            var productService = new ProductService(context);
            var newProductRequest = new ProductRequest { ProductName = "Beef", CategoryId = 25, CategoryName = "Meat" };
            //Act
            productService.Add(newProductRequest);

            //Assert
            var products = context.Products.ToList();
            Assert.Single(products);
        }
    }
}