using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetByIdWithHouse
{
	public class GetReservationByIdWithHouseQuery : IRequest<GetReservationByIdWithHouseResponse>
	{
		public int Id { get; set; }

		public GetReservationByIdWithHouseQuery(int id)
		{
			Id = id;
		}

		public class GetByIdWithHouseQueryHandler : IRequestHandler<GetReservationByIdWithHouseQuery, GetReservationByIdWithHouseResponse>
		{
			private readonly IReservationRepository _repository;
			private readonly IMapper _mapper;

			public GetByIdWithHouseQueryHandler(IReservationRepository repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetReservationByIdWithHouseResponse> Handle(GetReservationByIdWithHouseQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetReservationWithHouse(request.Id);

				var response = _mapper.Map<GetReservationByIdWithHouseResponse>(entity);
				return response;
			}
		}
	}
}
