using ProductManagement.Core.Models;
using System;

namespace ProductManagement.Core.Services
{
    public class ProductRequestService
    {
        public ProductRequestService()
        {
        }

        public ProductResult AddProduct(ProductRequest productRequest)
        {
            if (productRequest is null)
                throw new ArgumentNullException(nameof(productRequest));

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