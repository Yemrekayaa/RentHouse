using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Testimonials.Commands.Update
{
    public class UpdateTestimonialCommand : IRequest
    {
        public int TestimonialID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

        public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
        {
            private readonly IRepository<Testimonial> _repository;
            private readonly IMapper _mapper;

            public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.TestimonialID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
