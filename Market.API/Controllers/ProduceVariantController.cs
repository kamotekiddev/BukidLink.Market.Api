using Market.Application.DTOs.ProduceVariant;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceVariantController : ControllerBase
    {
        private readonly IProduceVariantService _produceVariantService;

        public ProduceVariantController(IProduceVariantService produceVariantService)
        {
            _produceVariantService = produceVariantService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var produceVariants = await _produceVariantService.GetByIdAsync(id);
            return Ok(produceVariants);
        }

        [HttpGet("produce/{produceId}")]
        public async Task<IActionResult> GetByProduceId([FromRoute] Guid produceId)
        {
            var produceVariants = await _produceVariantService.GetByProduceIdAsync(produceId);
            return Ok(produceVariants);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] AddProduceVariantDto dto)
        {
            var produceVariant = await _produceVariantService.AddAsync(dto);
            return Ok(produceVariant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProduceVariantDto dto)
        {
            var produceVariant = await _produceVariantService.UpdateAsync(id, dto);
            return Ok(produceVariant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var produceVariant = await _produceVariantService.DeleteAsync(id);
            return Ok(produceVariant);
        }
    }
}