using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetById
{
	public class GetByIdReservationQuery : IRequest<GetByIdReservationResponse>
	{
		public int Id { get; set; }

		public GetByIdReservationQuery(int id)
		{
			Id = id;
		}

		public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQuery, GetByIdReservationResponse>
		{
			private readonly IRepository<Reservation> _repository;
			private readonly IMapper _mapper;

			public GetByIdReservationQueryHandler(IRepository<Reservation> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdReservationResponse> Handle(GetByIdReservationQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdReservationResponse>(entity);
				return response;
			}
		}
	}
}
