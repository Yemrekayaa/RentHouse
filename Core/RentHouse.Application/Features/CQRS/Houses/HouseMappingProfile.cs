using AutoMapper;
using RentHouse.Application.Common.HouseFeature;
using RentHouse.Application.Features.CQRS.Houses.Commands.Create;
using RentHouse.Application.Features.CQRS.Houses.Commands.Update;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetById;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetList;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetListWithLocationByDate;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocation;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocationById;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses
{
    public class HouseMappingProfile : Profile
    {
        public HouseMappingProfile()
        {
            CreateMap<House, GetListHouseResponse>().ReverseMap();
            CreateMap<House, GetByIdHouseResponse>().ReverseMap();
            CreateMap<UpdateHouseCommand, House>().ReverseMap();
            CreateMap<CreateHouseCommand, House>().ReverseMap();
            CreateMap<House, GetHouseWithLocationResponse>().
                ForMember(destinationMember => destinationMember.LocationName,
                          memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Location.Name));
            CreateMap<GetHouseWithLocationByIdResponse, House>().ReverseMap();
            CreateMap<House, GetHouseWithLocationByDateResponse>().ForMember(destinationMember => destinationMember.LocationName,
                          memberOptions => memberOptions.MapFrom(sourceMember => sourceMember.Location.Name)); ;
            CreateMap<CreateHouseFeatureDto, HouseFeature>()
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.FeatureId))
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Available));
            CreateMap<CreateHouseWithFeaturesCommand, House>().ReverseMap();
            CreateMap<UpdateHouseWithFeaturesCommand, House>().ReverseMap();
            CreateMap<UpdateHouseFeatureDto, HouseFeature>()
            .ForMember(dest => dest.FeatureId, opt => opt.MapFrom(src => src.FeatureId))
            .ForMember(dest => dest.Available, opt => opt.MapFrom(src => src.Available));
        }
    }
}

