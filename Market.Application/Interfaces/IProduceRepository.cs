using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IProduceRepository
{
    Task<Produce> AddProduceAsync(Produce produce);
    Task<Produce> UpdateProduceAsync(Produce produce);
    ValueTask<Produce?> GetProduceByIdAsync(Guid produceId);
    Task<Produce> DeleteProduceByIdAsync(Produce produce);
    Task<List<Produce>> GetAllProduceAsync();
}