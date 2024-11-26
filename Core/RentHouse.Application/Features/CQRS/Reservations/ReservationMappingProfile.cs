using AutoMapper;
using RentHouse.Application.Features.CQRS.Reservations.Commands.Create;
using RentHouse.Application.Features.CQRS.Reservations.Commands.Update;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetById;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetByIdWithHouse;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetList;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetListWithHouse;
using RentHouse.Application.Features.CQRS.Reservations.Queries.GetLisyByHouseId;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Reservations
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Reservation, GetListReservationResponse>().ReverseMap();
            CreateMap<Reservation, GetByIdReservationResponse>().ReverseMap();
            CreateMap<UpdateReservationCommand, Reservation>().ReverseMap();
            CreateMap<CreateReservationCommand, Reservation>().ReverseMap();
            CreateMap<GetReservationsByHouseIdResponse, Reservation>().ReverseMap();
            CreateMap<Reservation, GetReservationByIdWithHouseResponse>()
           .ForMember(dest => dest.HouseName, opt => opt.MapFrom(src => src.House.Name));
            CreateMap<Reservation, GetReservationListWithHouseResponse>()
           .ForMember(dest => dest.HouseName, opt => opt.MapFrom(src => src.House.Name));
        }
    }
}
