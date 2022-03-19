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

        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductResult> GetAvailableProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
