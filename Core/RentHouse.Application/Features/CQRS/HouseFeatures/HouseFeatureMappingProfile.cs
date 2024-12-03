using AutoMapper;
using RentHouse.Application.Features.CQRS.HouseFeatures.Commands;
using RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetByHouseId;
using RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetById;
using RentHouse.Application.Features.CQRS.Houses.Queries.GetWithFeaturesById;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseFeatures
{
    public class HouseFeatureMappingProfile : Profile
    {
        public HouseFeatureMappingProfile()
        {
            CreateMap<HouseFeature, GetHouseFeatureByHouseIdResponse>().ForMember(dest => dest.FeatureName,
                opt => opt.MapFrom(src => src.Feature.Name));
            CreateMap<HouseFeature, GetHouseFeatureByIdResponse>().ReverseMap();
            CreateMap<HouseFeature, CreateHouseFeatureByHouseCommand>().ReverseMap();
            CreateMap<House, GetHouseWithFeaturesByIdResponse>()
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name))
            .ForMember(dest => dest.HouseFeatures, opt => opt.MapFrom(src => src.HouseFeatures));


            CreateMap<HouseFeature, GetHouseWithFeaturesByIdFeatureListResponse>()
                .ForMember(dest => dest.FeatureName, opt => opt.MapFrom(src => src.Feature.Name));
        }
    }
}

