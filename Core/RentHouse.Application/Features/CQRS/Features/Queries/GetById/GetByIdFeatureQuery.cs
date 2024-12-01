using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Features.Queries.GetById
{
	public class GetByIdFeatureQuery : IRequest<GetByIdFeatureResponse>
	{
		public int Id { get; set; }

		public GetByIdFeatureQuery(int id)
		{
			Id = id;
		}

		public class GetByIdFeatureQueryHandler : IRequestHandler<GetByIdFeatureQuery, GetByIdFeatureResponse>
		{
			private readonly IRepository<Feature> _repository;
			private readonly IMapper _mapper;

			public GetByIdFeatureQueryHandler(IRepository<Feature> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdFeatureResponse> Handle(GetByIdFeatureQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdFeatureResponse>(entity);
				return response;
			}
		}
	}
}
