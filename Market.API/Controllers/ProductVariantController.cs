using Market.Application.DTOs.ProductVariant;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/products/variants")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IProductVariantService _productVariantService;

        public ProductVariantController(IProductVariantService productVariantService)
        {
            _productVariantService = productVariantService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var variant = await _productVariantService.GetByIdAsync(id);
            return Ok(variant);
        }

        [HttpGet("produce/{produceId}")]
        public async Task<IActionResult> GetByProduceId([FromRoute] Guid produceId)
        {
            var variants = await _productVariantService.GetByProduceIdAsync(produceId);
            return Ok(variants);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AddProductVariantDto dto)
        {
            var variant = await _productVariantService.AddAsync(dto);
            return Ok(variant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductVariantDto dto)
        {
            var variant = await _productVariantService.UpdateAsync(id, dto);
            return Ok(variant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var variant = await _productVariantService.DeleteAsync(id);
            return Ok(variant);
        }
    }
}