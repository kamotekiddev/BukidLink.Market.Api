using Market.Application.DTOs.Inventory;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/inventories")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryById([FromRoute] Guid id)
        {
            var inventory = await _inventoryService.GetByIdAsync(id);
            return Ok(inventory);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventories()
        {
            var inventories = await _inventoryService.GetAllAsync();
            return Ok(inventories);
        }

        [HttpGet("{produceId}")]
        public async Task<IActionResult> GetAllInventoriesByProduceId([FromRoute] Guid produceId)
        {
            var inventories = await _inventoryService.GetByProduceIdAsync(produceId);
            return Ok(inventories);
        }

        [HttpPost]
        public async Task<IActionResult> AddInventory([FromBody] AddInventoryDto dto)
        {
            var inventory = await _inventoryService.CreateAsync(dto);
            return Ok(inventory);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteInventory([FromRoute] Guid id)
        {
            await _inventoryService.DeleteAsync(id);
            return Ok(new { Message = "Inventory deleted successfully." });
        }
    }
}