using ProductManagement.Core.Domain;
using ProductManagement.Core.Models;
using System;

namespace ProductManagement.Core.DataServices
{
    public class ProductService: IProductService
    {
        public ProductService()
        {
        }        

        public void Save(ProductRequest product)
        {
            throw new NotImplementedException();
        }
    }
}