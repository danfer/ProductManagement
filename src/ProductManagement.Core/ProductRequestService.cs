using System;

namespace ProductManagement.Core
{
    public class ProductRequestService
    {
        public ProductRequestService()
        {
        }

        public ProductResult AddProduct(ProductRequest productRequest)
        {
            return new ProductResult
            {
                ProductId = productRequest.ProductId,
                ProductName = productRequest.ProductName,
                CategoryId = productRequest.CategoryId,
                CategoryName = productRequest.CategoryName,
            };
        }
    }
}