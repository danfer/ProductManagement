using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using ProductManagement.Core.Models;
using ProductManagement.Core.Services;

namespace ProductManagement.Test
{
    public class ProductRequestServiceTest
    {
        private ProductRequestService _service;

        public ProductRequestServiceTest()
        {
            //Arrange
            _service = new ProductRequestService();
        }

        [Fact]
        public void ShouldReturnProductRequestValues()
        {
            //Arrange
            var request = new ProductRequest
            {
                ProductId = 1,
                ProductName = "Mazola Oil",
                CategoryId = 10,
                CategoryName = "Cooking Oil",
            };

            //Act
            ProductResult result = _service.AddProduct(request);

            //Assert
            Assert.NotNull(result);
            
            Assert.Equal(request.ProductId, result.ProductId);
            Assert.Equal(request.ProductName, result.ProductName);
            Assert.Equal(request.CategoryId, result.CategoryId);
            Assert.Equal(request.CategoryName, result.CategoryName);

            result.ShouldNotBeNull();
            result.ProductName.ShouldBe(request.ProductName);
        }

        [Fact]
        public void ShouldThrowExceptionForNullRequest()
        {
            //Act
            var exception = Should.Throw<ArgumentNullException>(() => _service.AddProduct(null));

            //Assert
            exception.ParamName.ShouldBe("productRequest");
        }
    }
}
