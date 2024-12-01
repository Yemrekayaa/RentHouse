using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetListWithHouse
{
	public class GetReservationListWithHouseQuery : IRequest<List<GetReservationListWithHouseResponse>>
	{
		public class GetListReservationQueryHandler : IRequestHandler<GetReservationListWithHouseQuery, List<GetReservationListWithHouseResponse>>
		{
			private readonly IReservationRepository _repository;
			private readonly IMapper _mapper;

			public GetListReservationQueryHandler(IReservationRepository repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetReservationListWithHouseResponse>> Handle(GetReservationListWithHouseQuery request, CancellationToken cancellationToken)
			{
				var entities = await _repository.GetReservationListWithHouse();

				var response = _mapper.Map<List<GetReservationListWithHouseResponse>>(entities);
				return response;
			}
		}

	}
}


