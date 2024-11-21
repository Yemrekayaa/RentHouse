using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Testimonials.Commands.Create
{
    public class CreateTestimonialCommand : IRequest
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

        public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
        {
            private readonly IRepository<Testimonial> _repository;
            private readonly IMapper _mapper;
            public CreateTestimonialCommandHandler(IRepository<Testimonial> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Testimonial>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
