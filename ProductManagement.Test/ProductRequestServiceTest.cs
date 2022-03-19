using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using ProductManagement.Core.Models;
using ProductManagement.Core.DataServices;
using ProductManagement.Core.Processors;
using Moq;
using ProductManagement.Core.Domain;

namespace ProductManagement.Test
{
    public class ProductRequestServiceTest
    {
        private ProductProcessor _processor;
        private ProductRequest _request;
        private Mock<IProductService> _productServiceMock;
        private List<ProductResult> _availableProducts;

        public ProductRequestServiceTest()
        {
            //Arrange
            _request = new ProductRequest
            {
                ProductId = 1,
                ProductName = "Mazola Oil",
                CategoryId = 10,
                CategoryName = "Cooking Oil",
            };

            _availableProducts = new List<ProductResult>() { new ProductResult() };

            _productServiceMock = new Mock<IProductService>();
            _productServiceMock.Setup(x => x.GetAvailableProducts())
                .Returns(_availableProducts);

            _processor = new ProductProcessor(_productServiceMock.Object);            
        }

        [Fact]
        public void ShouldReturnProductRequestValues()
        {
            //Arrange            

            //Act
            ProductResult result = _processor.AddProduct(_request);

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
            var exception = Should.Throw<ArgumentNullException>(() => _processor.AddProduct(null));

            //Assert
            exception.ParamName.ShouldBe("productRequest");
        }

        [Fact]
        public void ShouldSaveProductRequest()
        {
            Product savedProduct = null;
            _productServiceMock.Setup(q => q.Save(It.IsAny<Product>()))
                .Callback<Product>(product =>
                {
                    savedProduct = product;
                });
            _processor.AddProduct(_request);

            _productServiceMock.Verify(q => q.Save(It.IsAny<Product>()), Times.Once);

            savedProduct.ShouldNotBeNull();

            savedProduct.ProductName.ShouldBe(_request.ProductName);
        }

        [Fact]
        public void ShouldGetAvailableProducts()
        {
            List<ProductResult> availableProducts = new List<ProductResult>();
           
            availableProducts = _processor.GetAvailableProducts().ToList();

            _productServiceMock.Verify(q => q.GetAvailableProducts(), Times.Once);

            availableProducts.ShouldNotBeNull();

            availableProducts.Count().ShouldBeInRange<int>(0, 1);
        }
    }
}
