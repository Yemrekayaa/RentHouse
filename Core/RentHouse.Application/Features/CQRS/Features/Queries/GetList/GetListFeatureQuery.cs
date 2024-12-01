using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Features.Queries.GetList
{
	public class GetListFeatureQuery : IRequest<List<GetListFeatureResponse>>
	{
		public class GetListFeatureQueryHandler : IRequestHandler<GetListFeatureQuery, List<GetListFeatureResponse>>
		{
			private readonly IRepository<Feature> _repository;
			private readonly IMapper _mapper;

			public GetListFeatureQueryHandler(IRepository<Feature> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetListFeatureResponse>> Handle(GetListFeatureQuery request, CancellationToken cancellationToken)
			{
				var entities = await _repository.GetAllAsync();

				var response = _mapper.Map<List<GetListFeatureResponse>>(entities);
				return response;
			}
		}

	}
}


