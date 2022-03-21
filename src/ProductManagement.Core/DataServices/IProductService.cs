using ProductManagement.Core.Models;
using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.DataServices
{
    public interface IProductService
    {
        ProductResult GetProduct(int id);
        ProductResult Add(ProductRequest product);
        void Update(ProductRequest product);
        IEnumerable<ProductResult> GetAvailableProducts();
        void Delete(ProductRequest product);
    }
}
