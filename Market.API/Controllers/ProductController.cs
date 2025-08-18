using Market.Application.DTOs.Product;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProduceById([FromRoute] Guid productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId([FromRoute] Guid categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduce([FromBody] AddProductDto dto)
        {
            var product = await _productService.CreateProductAsync(dto);
            return Ok(product);
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateProduce([FromRoute] Guid productId, [FromBody] UpdateProductDto dto)
        {
            var product = await _productService.UpdateProductAsync(productId, dto);
            return Ok(product);
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProduce([FromRoute] Guid productId)
        {
            var produce = await _productService.DeleteProductByIdAsync(productId);
            return Ok(produce);
        }
    }
}