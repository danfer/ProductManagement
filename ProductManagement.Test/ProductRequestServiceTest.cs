using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductManagement.Test
{
    public class ProductRequestServiceTest
    {
        [Fact]
        public void ShouldReturnProductRequestValues()
        {
            var productRequest = new ProductRequest
            {
                ProductName = "Mazola Oil",
            };
            var service = new ProductRequestService();

            ProductResult result = service.Products(productRequest);
        }
    }
}
