using ProductManagement.Core.Domain;
using ProductManagement.Core.Models;
using System;

namespace ProductManagement.Core.DataServices
{
    public class ProductService: IProductService
    {
        public ProductService()
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

        public void Save(ProductRequest product)
        {
            throw new NotImplementedException();
        }
    }
}