using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.Models;
using ProductManagement.Core.Processors;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductProcessor _productProcessor
            ;

        public ProductsController(IProductProcessor productProcessor)
        {
            _productProcessor = productProcessor;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _productProcessor.AddProduct(request);
                if (result.Flag == Core.Enums.ProductResultFlag.Success)
                {
                    return Ok(result);
                }
                ModelState.AddModelError(nameof(ProductRequest.CategoryId), "No category included");
            }
            return BadRequest(ModelState);
        }
    }
}
