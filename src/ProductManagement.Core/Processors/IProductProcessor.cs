using ProductManagement.Core.Models;

namespace ProductManagement.Core.Processors
{
    public interface IProductProcessor
    {
        ProductResult AddProduct(ProductRequest productRequest);
        void DeleteProduct(ProductRequest productRequest);
        IEnumerable<ProductResult> GetAvailableProducts();
        ProductResult GetProduct(ProductRequest productRequest);
        ProductResult UpdateProduct(ProductRequest productRequest);
    }
}