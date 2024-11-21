using AutoMapper;
using RentHouse.Application.Features.CQRS.Services.Commands.Create;
using RentHouse.Application.Features.CQRS.Services.Commands.Update;
using RentHouse.Application.Features.CQRS.Services.Queries.GetById;
using RentHouse.Application.Features.CQRS.Services.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Services
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, GetListServiceResponse>().ReverseMap();
            CreateMap<Service, GetByIdServiceResponse>().ReverseMap();
            CreateMap<UpdateServiceCommand, Service>().ReverseMap();
            CreateMap<CreateServiceCommand, Service>().ReverseMap();
        }
    }
}
