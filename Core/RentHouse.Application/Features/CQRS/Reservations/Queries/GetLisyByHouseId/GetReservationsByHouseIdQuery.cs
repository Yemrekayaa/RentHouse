using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

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
			private readonly IRepository<Reservation> _repository;
			private readonly IMapper _mapper;

			public GetByIdReservationQueryHandler(IRepository<Reservation> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetReservationsByHouseIdResponse>> Handle(GetReservationsByHouseIdQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.Where(x => x.HouseID == request.Id);

				var response = _mapper.Map<List<GetReservationsByHouseIdResponse>>(entity);
				return response;
			}
		}
	}
}
