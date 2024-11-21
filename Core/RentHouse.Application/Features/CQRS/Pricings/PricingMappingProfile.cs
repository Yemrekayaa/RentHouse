using AutoMapper;
using RentHouse.Application.Features.CQRS.Pricings.Commands.Create;
using RentHouse.Application.Features.CQRS.Pricings.Commands.Update;
using RentHouse.Application.Features.CQRS.Pricings.Queries.GetById;
using RentHouse.Application.Features.CQRS.Pricings.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Pricings
{
    public class PricingMappingProfile : Profile
    {
        public PricingMappingProfile()
        {
            CreateMap<Pricing, GetListPricingResponse>().ReverseMap();
            CreateMap<Pricing, GetByIdPricingResponse>().ReverseMap();
            CreateMap<UpdatePricingCommand, Pricing>().ReverseMap();
            CreateMap<CreatePricingCommand, Pricing>().ReverseMap();
        }
    }
}
