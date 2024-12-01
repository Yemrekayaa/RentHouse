using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Testimonials.Queries.GetById
{
	public class GetByIdTestimonialQuery : IRequest<GetByIdTestimonialResponse>
	{
		public int Id { get; set; }

		public GetByIdTestimonialQuery(int id)
		{
			Id = id;
		}

		public class GetByIdTestimonialQueryHandler : IRequestHandler<GetByIdTestimonialQuery, GetByIdTestimonialResponse>
		{
			private readonly IRepository<Testimonial> _repository;
			private readonly IMapper _mapper;

			public GetByIdTestimonialQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdTestimonialResponse> Handle(GetByIdTestimonialQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdTestimonialResponse>(entity);
				return response;
			}
		}
	}
}
