using AutoMapper;
using Market.Application.DTOs.Produce;
using Market.Application.DTOs.User;
using Market.Domain.Entities;

namespace Market.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Produce, ProduceDto>();
    }
}