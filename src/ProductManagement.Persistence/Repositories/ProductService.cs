using ProductManagement.Core.DataServices;
using ProductManagement.Core.Models;
using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Repositories
{
    public class ProductService : IProductService
    {
        public ProductService(ProductManagementDbContext context)
        {
            _context = context;
        }

        public ProductManagementDbContext _context { get; }

        public void Add(ProductRequest product)
        {
            var lastProduct = _context.Products.OrderByDescending(p => p.ProductId).FirstOrDefault();
            int nextProductId = 1;
            if (lastProduct != null)
                nextProductId = lastProduct.ProductId;

            _context.Products.Add(new Product
            {
                ProductId = nextProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                CategoryName = product.CategoryName
            });
            _context.SaveChanges();
        }

        public void Delete(ProductRequest product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResult> GetAvailableProducts()
        {
            var availableProducts = _context.Products
                .Where(p => p.Quantity > 0)
                .ToList();

            return availableProducts.Select(x => new ProductResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Quantity = x.Quantity,
            }).ToList();
        }

        public void Update(ProductRequest product)
        {
            throw new NotImplementedException();
        }

        ProductResult IProductService.GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
