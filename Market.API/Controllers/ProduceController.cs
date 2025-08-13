using Market.Application.DTOs.Produce;
using Market.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduceController : ControllerBase
    {
        private readonly IProduceService _produceService;

        public ProduceController(IProduceService produceService)
        {
            _produceService = produceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducers()
        {
            var produce = await _produceService.GetAllProduceAsync();
            return Ok(produce);
        }

        [HttpGet("{produceId:guid}")]
        public async Task<IActionResult> GetProduceById([FromRoute] Guid produceId)
        {
            var produce = await _produceService.GetProduceByIdAsync(produceId);
            return Ok(produce);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduce([FromBody] AddProduceDto dto)
        {
            var produce = await _produceService.CreateProduceAsync(dto);
            return Ok(produce);
        }

        [HttpPut("{produceId:guid}")]
        public async Task<IActionResult> UpdateProduce([FromRoute] Guid produceId, [FromBody] UpdateProduceDto dto)
        {
            var produce = await _produceService.UpdateProduceAsync(produceId, dto);
            return Ok(produce);
        }

        [HttpDelete("{produceId:guid}")]
        public async Task<IActionResult> DeleteProduce([FromRoute] Guid produceId)
        {
            var produce = await _produceService.DeleteProduceByIdAsync(produceId);
            return Ok(produce);
        }
    }
}