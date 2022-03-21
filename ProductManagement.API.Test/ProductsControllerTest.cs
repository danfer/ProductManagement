using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagement.API.Controllers;
using ProductManagement.Core.Enums;
using ProductManagement.Core.Models;
using ProductManagement.Core.Processors;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductManagement.API.Test
{
    public class ProductsControllerTest
    {
        private Mock<IProductProcessor> _productProcessor;
        private ProductsController _controller;
        private ProductRequest _request;
        private ProductResult _result;
        public ProductsControllerTest()
        {
            _productProcessor = new Mock<IProductProcessor>();
            _controller = new ProductsController(_productProcessor.Object);
            _request = new ProductRequest();
            _result = new ProductResult();

            _productProcessor.Setup(x => x.AddProduct(_request)).Returns(_result);
        }

        [Theory]
        [InlineData(1, true, typeof(OkObjectResult), ProductResultFlag.Success)]
        [InlineData(0, false, typeof(BadRequestObjectResult), ProductResultFlag.Failure)]
        public void ShouldCallProductMethodWhenValid(int expectedMethodCalls, bool isModelValid, Type expectedActionResultType,
                                                            ProductResultFlag productResultFlag)
        {
            // Arrange
            if (!isModelValid)
            {
                _controller.ModelState.AddModelError("Key", "ErrorMessage");
            }
            _result.Flag = productResultFlag;

            // Act
            var result = _controller.AddProduct(_request);

            // Assert
            result.ShouldBeOfType(expectedActionResultType);
            _productProcessor.Verify(x => x.AddProduct(_request), Times.Exactly(expectedMethodCalls));
        }
    }
}
