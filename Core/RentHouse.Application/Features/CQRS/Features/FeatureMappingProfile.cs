using AutoMapper;
using RentHouse.Application.Features.CQRS.Features.Commands.Create;
using RentHouse.Application.Features.CQRS.Features.Commands.Update;
using RentHouse.Application.Features.CQRS.Features.Queries.GetById;
using RentHouse.Application.Features.CQRS.Features.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Features
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<Feature, GetListFeatureResponse>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureResponse>().ReverseMap();
            CreateMap<UpdateFeatureCommand, Feature>().ReverseMap();
            CreateMap<CreateFeatureCommand, Feature>().ReverseMap();
        }
    }
}
