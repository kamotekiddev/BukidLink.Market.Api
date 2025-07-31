using Market.Application.DTOs;
using Market.Application.DTOs.Store;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }


        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] AddStoreDto dto)
        {
            var store = await _storeService.AddStoreAsync(dto);
            return Ok(store);
        }

        [HttpPut("{storeId:guid}")]
        public async Task<IActionResult> UpdateStore([FromRoute] Guid storeId, [FromBody] UpdateStoreDto dto)
        {
            var store = await _storeService.UpdateStoreAsync(storeId, dto);
            return Ok(store);
        }


        [HttpDelete("{storeId:guid}")]
        public async Task<IActionResult> RemoveStore([FromRoute] Guid storeId)
        {
            var store = await _storeService.RemoveStoreAsync(storeId);
            return Ok(store);
        }
    }
}