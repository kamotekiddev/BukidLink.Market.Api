using Market.Application.DTOs.ProduceCategory;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceCategoryController : ControllerBase
    {
        private IProduceCategoryService _produceCategoryService;

        public ProduceCategoryController(IProduceCategoryService produceCategoryService)
        {
            _produceCategoryService = produceCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduceCategories()
        {
            var categories = await _produceCategoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduceCategoryById(Guid id)
        {
            var category = await _produceCategoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduceCategory([FromBody] AddProduceCategoryDto dto)
        {
            var category = await _produceCategoryService.AddAsync(dto);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddProduceCategory([FromRoute] Guid id,
            [FromBody] UpdateProduceCategoryDto dto)
        {
            var category = await _produceCategoryService.UpdateAsync(id, dto);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduceCategoryById([FromRoute] Guid id)
        {
            var category = await _produceCategoryService.DeleteAsync(id);
            return Ok(new { Message = "Produce category deleted successfully.", data = category });
        }
    }
}