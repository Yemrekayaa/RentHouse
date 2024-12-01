using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetLisyByHouseId
{
	public class GetReservationsByHouseIdQuery : IRequest<List<GetReservationsByHouseIdResponse>>
	{
		public int Id { get; set; }

		public GetReservationsByHouseIdQuery(int id)
		{
			Id = id;
		}

		public class GetByIdReservationQueryHandler : IRequestHandler<GetReservationsByHouseIdQuery, List<GetReservationsByHouseIdResponse>>
		{
			private readonly IReservationRepository _repository;
			private readonly IMapper _mapper;

			public GetByIdReservationQueryHandler(IReservationRepository repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetReservationsByHouseIdResponse>> Handle(GetReservationsByHouseIdQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetListWithHouseByHouse(request.Id);

				var response = _mapper.Map<List<GetReservationsByHouseIdResponse>>(entity);
				return response;
			}
		}
	}
}
