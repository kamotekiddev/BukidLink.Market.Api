using AutoMapper;
using Market.Application.DTOs.Inventory;
using Market.Application.DTOs.Produce;
using Market.Application.DTOs.ProduceVariant;
using Market.Application.DTOs.User;
using Market.Domain.Entities;

namespace Market.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Produce, ProduceDto>().ReverseMap();
        CreateMap<Inventory, InventoryDto>().ReverseMap();
        CreateMap<ProduceVariant, ProduceVariantDto>().ReverseMap();
    }
}