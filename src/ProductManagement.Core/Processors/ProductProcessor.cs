using ProductManagement.Core.DataServices;
using ProductManagement.Core.Domain;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.Processors
{
    public class ProductProcessor
    {
        private readonly IProductService _productService;
        public ProductProcessor(IProductService productService)
        {
            _productService = productService;
        }

        public ProductResult AddProduct(ProductRequest productRequest)
        {
            if (productRequest is null)
                throw new ArgumentNullException(nameof(productRequest));

            _productService.Add(CreateProductObject<Product>(productRequest));

            return CreateProductObject<ProductResult>(productRequest);
        }

        public ProductResult UpdateProduct(ProductRequest productRequest)
        {
            if (productRequest is null)
                throw new ArgumentNullException(nameof(productRequest));

            _productService.Update(CreateProductObject<Product>(productRequest));

            return CreateProductObject<ProductResult>(productRequest);
        }

        public ProductResult GetProduct(ProductRequest productRequest)
        {
            if (productRequest is null)
                throw new ArgumentNullException(nameof(productRequest));

            return CreateProductObject<ProductResult>(productRequest);
        }

        public void DeleteProduct(ProductRequest productRequest)
        {
            if (productRequest is null)
                throw new ArgumentNullException(nameof(productRequest));

            _productService.Delete(_productService.GetProduct(productRequest.ProductId));
        }

        public IEnumerable<ProductResult> GetAvailableProducts()
        {
            var products = _productService.GetAvailableProducts();

            return products.Select(x => new ProductResult
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Quantity = x.Quantity,
            }).ToList();
        }

        //Generic method can use any class inheriting from ProductBase
        private TProduct CreateProductObject<TProduct>(ProductRequest productRequest) where TProduct 
            : ProductBase, new()
        {
            return new TProduct
                {

                ProductId = productRequest.ProductId,
                ProductName = productRequest.ProductName,
                CategoryId = productRequest.CategoryId,
                CategoryName = productRequest.CategoryName,
            };
        }
    }
}
