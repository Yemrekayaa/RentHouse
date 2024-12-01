using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Testimonials.Queries.GetList
{
	public class GetListTestimonialQuery : IRequest<List<GetListTestimonialResponse>>
	{
		public class GetListTestimonialQueryHandler : IRequestHandler<GetListTestimonialQuery, List<GetListTestimonialResponse>>
		{
			private readonly IRepository<Testimonial> _repository;
			private readonly IMapper _mapper;

			public GetListTestimonialQueryHandler(IRepository<Testimonial> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetListTestimonialResponse>> Handle(GetListTestimonialQuery request, CancellationToken cancellationToken)
			{
				var entities = await _repository.GetAllAsync();

				var response = _mapper.Map<List<GetListTestimonialResponse>>(entities);
				return response;
			}
		}

	}
}


