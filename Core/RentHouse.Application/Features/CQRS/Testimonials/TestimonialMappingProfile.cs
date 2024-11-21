using AutoMapper;
using RentHouse.Application.Features.CQRS.Testimonials.Commands.Create;
using RentHouse.Application.Features.CQRS.Testimonials.Commands.Update;
using RentHouse.Application.Features.CQRS.Testimonials.Queries.GetById;
using RentHouse.Application.Features.CQRS.Testimonials.Queries.GetList;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Testimonials
{
    public class TestimonialMappingProfile : Profile
    {
        public TestimonialMappingProfile()
        {
            CreateMap<Testimonial, GetListTestimonialResponse>().ReverseMap();
            CreateMap<Testimonial, GetByIdTestimonialResponse>().ReverseMap();
            CreateMap<UpdateTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<CreateTestimonialCommand, Testimonial>().ReverseMap();
        }
    }
}
