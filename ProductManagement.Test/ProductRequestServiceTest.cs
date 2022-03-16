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
        public void ShouldReturnProductRequest()
        {
            var productRequest = new ProductRequest
            {
                ProductId = 1,
                ProductName = "Mazola Oil",
                CategoryId = 10,
                CategoryName = "Cooking Oil"
            };
            var service = new ProductRequestService();
        }
    }
}
