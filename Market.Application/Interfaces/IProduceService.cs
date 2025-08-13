using Market.Application.DTOs.Produce;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProduceService
{
    Task<ProduceDto> CreateProduceAsync(AddProduceDto dto);
    Task<List<ProduceDto>> GetAllProduceAsync();
    Task<ProduceDto> GetProduceByIdAsync(Guid produceId);
    Task<ProduceDto> UpdateProduceAsync(Guid produceId, UpdateProduceDto dto);
    Task<ProduceDto> DeleteProduceByIdAsync(Guid produceId);
}