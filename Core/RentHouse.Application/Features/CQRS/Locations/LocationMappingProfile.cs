using AutoMapper;
using RentHouse.Application.Features.CQRS.Locations.Commands.Create;
using RentHouse.Application.Features.CQRS.Locations.Commands.Update;
using RentHouse.Application.Features.CQRS.Locations.Queries.GetById;
using RentHouse.Application.Features.CQRS.Locations.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, GetListLocationResponse>().ReverseMap();
            CreateMap<Location, GetByIdLocationResponse>().ReverseMap();
            CreateMap<UpdateLocationCommand, Location>().ReverseMap();
            CreateMap<CreateLocationCommand, Location>().ReverseMap();
        }
    }
}
