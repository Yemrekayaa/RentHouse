using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations.Queries.GetList
{
	public class GetListLocationQuery : IRequest<List<GetListLocationResponse>>
	{
		public class GetListLocationQueryHandler : IRequestHandler<GetListLocationQuery, List<GetListLocationResponse>>
		{
			private readonly IRepository<Location> _repository;
			private readonly IMapper _mapper;

			public GetListLocationQueryHandler(IRepository<Location> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetListLocationResponse>> Handle(GetListLocationQuery request, CancellationToken cancellationToken)
			{
				var entities = await _repository.GetAllAsync();

				var response = _mapper.Map<List<GetListLocationResponse>>(entities);
				return response;
			}
		}

	}
}


