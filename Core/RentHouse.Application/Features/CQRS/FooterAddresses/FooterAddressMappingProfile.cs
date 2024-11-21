using AutoMapper;
using RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Create;
using RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Update;
using RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetById;
using RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.FooterAddresses
{
    public class FooterAddressMappingProfile : Profile
    {
        public FooterAddressMappingProfile()
        {
            CreateMap<FooterAddress, GetListFooterAddressResponse>().ReverseMap();
            CreateMap<FooterAddress, GetByIdFooterAddressResponse>().ReverseMap();
            CreateMap<UpdateFooterAddressCommand, FooterAddress>().ReverseMap();
            CreateMap<CreateFooterAddressCommand, FooterAddress>().ReverseMap();
        }
    }
}
