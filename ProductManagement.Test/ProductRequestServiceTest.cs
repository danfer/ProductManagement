using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using ProductManagement.Core.Models;
using ProductManagement.Core.DataServices;

namespace ProductManagement.Test
{
    public class ProductRequestServiceTest
    {
        private ProductService _service;
        private ProductRequest _request;

        public ProductRequestServiceTest()
        {
            //Arrange
            _service = new ProductService();

            _request = new ProductRequest
            {
                ProductId = 1,
                ProductName = "Mazola Oil",
                CategoryId = 10,
                CategoryName = "Cooking Oil",
            };
        }

        [Fact]
        public void ShouldReturnProductRequestValues()
        {
            //Arrange            

            //Act
            ProductResult result = _service.AddProduct(_request);

            //Assert
            Assert.NotNull(result);
            
            Assert.Equal(_request.ProductId, result.ProductId);
            Assert.Equal(_request.ProductName, result.ProductName);
            Assert.Equal(_request.CategoryId, result.CategoryId);
            Assert.Equal(_request.CategoryName, result.CategoryName);

            result.ShouldNotBeNull();
            result.ProductName.ShouldBe(_request.ProductName);
        }

        [Fact]
        public void ShouldThrowExceptionForNullRequest()
        {
            //Act
            var exception = Should.Throw<ArgumentNullException>(() => _service.AddProduct(null));

            //Assert
            exception.ParamName.ShouldBe("productRequest");
        }

        [Fact]
        public void ShouldSaveProductRequest()
        {
            _service.AddProduct(_request);
        }
    }
}
