using Xunit;
using Shouldly;
using System.Linq;
using Moq;
using Microsoft.Extensions.Logging;
using ProductManagement.API.Controllers;

namespace ProductManagement.API.Test
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnForecastResults()
        {
            //Arrange
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);

            //Act
            var result = controller.Get();

            //Assert
            result.Count().ShouldBeGreaterThan(1);
            result.ShouldNotBeNull();
        }
    }
}