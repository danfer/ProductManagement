using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using ProductManagement.Core;

namespace ProductManagement.Test
{
    public class ProductRequestServiceTest
    {
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
            var service = new ProductRequestService();

            //Act
            ProductResult result = service.AddProduct(request);

            //Assert
            Assert.NotNull(result);
            
            Assert.Equal(request.ProductId, result.ProductId);
            Assert.Equal(request.ProductName, result.ProductName);
            Assert.Equal(request.CategoryId, result.CategoryId);
            Assert.Equal(request.CategoryName, result.CategoryName);

            result.ShouldNotBeNull();
            result.ProductName.ShouldBe(request.ProductName);
        }
    }
}
