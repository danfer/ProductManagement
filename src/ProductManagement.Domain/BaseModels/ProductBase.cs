using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.BaseModels
{
    public abstract class ProductBase
    {
        public int ProductId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(250)]
        public string CategoryName { get; set; }
        public int Quantity { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(CategoryName))
            {
                yield return new ValidationResult("Product and or category names can´t be empty.");
            }
        }
    }
}
