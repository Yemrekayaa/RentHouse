using AutoMapper;
using RentHouse.Application.Features.CQRS.Contacts.Commands.Create;
using RentHouse.Application.Features.CQRS.Contacts.Commands.Update;
using RentHouse.Application.Features.CQRS.Contacts.Queries.GetById;
using RentHouse.Application.Features.CQRS.Contacts.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Contacts
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<Contact, GetListContactResponse>().ReverseMap();
            CreateMap<Contact, GetByIdContactResponse>().ReverseMap();
            CreateMap<UpdateContactCommand, Contact>().ReverseMap();
            CreateMap<CreateContactCommand, Contact>().ReverseMap();
        }
    }
}
