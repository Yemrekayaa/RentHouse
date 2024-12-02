using AutoMapper;
using RentHouse.Application.Features.CQRS.HouseFeatures.Commands;
using RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetByHouseId;
using RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetById;
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
		}
	}
}

