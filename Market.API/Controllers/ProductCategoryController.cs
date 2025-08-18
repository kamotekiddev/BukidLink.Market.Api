using Market.Application.DTOs.ProductCategory;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/products/categories")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduceCategories()
        {
            var categories = await _productCategoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduceCategoryById(Guid id)
        {
            var category = await _productCategoryService.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduceCategory([FromBody] AddProductCategoryDto dto)
        {
            var category = await _productCategoryService.AddAsync(dto);
            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddProduceCategory([FromRoute] Guid id,
            [FromBody] UpdateProductCategoryDto dto)
        {
            var category = await _productCategoryService.UpdateAsync(id, dto);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduceCategoryById([FromRoute] Guid id)
        {
            var category = await _productCategoryService.DeleteAsync(id);
            return Ok(new { Message = "Produce category deleted successfully.", data = category });
        }
    }
}