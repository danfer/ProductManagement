﻿using ProductManagement.Core.Domain;
using ProductManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Core.DataServices
{
    public interface IProductService
    {
        Product GetProduct(int id);
        void Add(Product product);
        void Update(Product product);
        IEnumerable<ProductResult> GetAvailableProducts();
        void Delete(Product product);
    }
}
