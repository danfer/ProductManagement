using ProductManagement.Core.Domain;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.DataServices
{
    internal interface IProductService
    {
        void Save(ProductRequest product);

        ProductResult AddProduct(ProductRequest productRequest);
    }
}
