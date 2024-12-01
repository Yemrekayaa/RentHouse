using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Statistics.Queries.GetList
{
	public class GetListStatisticQuery : IRequest<GetListStatisticResponse>
	{
		public class GetListStatisticQueryHandler : IRequestHandler<GetListStatisticQuery, GetListStatisticResponse>
		{
			private readonly IStatisticRepository _repository;
			private readonly IMapper _mapper;

			public GetListStatisticQueryHandler(IStatisticRepository repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetListStatisticResponse> Handle(GetListStatisticQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetAll();

				var response = _mapper.Map<GetListStatisticResponse>(entity);
				return response;
			}
		}

	}
}


