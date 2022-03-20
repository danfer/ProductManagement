using ProductManagement.Core.Enums;
using ProductManagement.Domain.BaseModels;

namespace ProductManagement.Core.Models
{
    public class ProductResult : ProductBase
    {
        public ProductResultFlag Flag { get; set; }
    }
}