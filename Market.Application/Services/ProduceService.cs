using AutoMapper;
using Market.Application.DTOs.Produce;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class ProduceService : IProduceService
{
    private readonly IProduceRepository _produceRepository;
    private readonly IMapper _mapper;

    public ProduceService(IProduceRepository produceRepository, IMapper mapper)
    {
        _produceRepository = produceRepository;
        _mapper = mapper;
    }

    public async Task<ProduceDto> CreateProduceAsync(AddProduceDto dto)
    {
        var produce = new Produce
        {
            Name = dto.Name,
            Description = dto.Description,
            PhotoUrl = dto.PhotoUrl,
        };

        await _produceRepository.AddProduceAsync(produce);
        return _mapper.Map<ProduceDto>(produce);
    }

    public async Task<List<ProduceDto>> GetAllProduceAsync()
    {
        var produce = await _produceRepository.GetAllProduceAsync();
        return _mapper.Map<List<ProduceDto>>(produce);
    }

    public async Task<ProduceDto> GetProduceByIdAsync(Guid produceId)
    {
        var produce = await _produceRepository.GetProduceByIdAsync(produceId) ??
                      throw new BadHttpRequestException($"produce with id:{produceId} not found.");

        return _mapper.Map<ProduceDto>(produce);
    }

    public async Task<ProduceDto> UpdateProduceAsync(Guid produceId, UpdateProduceDto dto)
    {
        var existingProduce = await _produceRepository.GetProduceByIdAsync(produceId) ??
                              throw new BadHttpRequestException("Produce does not exist.");

        existingProduce.Name = dto.Name;
        if (dto.PhotoUrl != null) existingProduce.PhotoUrl = dto.PhotoUrl;
        if (dto.Description != null) existingProduce.Description = dto.Description;

        await _produceRepository.UpdateProduceAsync(existingProduce);

        return _mapper.Map<ProduceDto>(existingProduce);
    }

    public async Task<ProduceDto> DeleteProduceByIdAsync(Guid produceId)
    {
        var existingProduce = await _produceRepository.GetProduceByIdAsync(produceId) ??
                              throw new BadHttpRequestException("Produce does not exist.");

        await _produceRepository.DeleteProduceByIdAsync(existingProduce);

        return _mapper.Map<ProduceDto>(existingProduce);
    }
}