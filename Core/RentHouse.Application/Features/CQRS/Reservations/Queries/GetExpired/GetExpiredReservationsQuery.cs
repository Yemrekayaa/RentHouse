using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetExpired
{
    public class GetExpiredReservationsQuery : IRequest<List<GetExpiredReservationsResponse>>
    {
        public class GetExpiredReservationsQueryHandler : IRequestHandler<GetExpiredReservationsQuery, List<GetExpiredReservationsResponse>>
        {
            private readonly IReservationRepository _reservationRepository;
            private readonly IMapper _mapper;

            public GetExpiredReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
            {
                _reservationRepository = reservationRepository;
                _mapper = mapper;
            }

            public async Task<List<GetExpiredReservationsResponse>> Handle(GetExpiredReservationsQuery request, CancellationToken cancellationToken)
            {
                var entities = await _reservationRepository.GetExpiredReservationsAsync();
                var response = _mapper.Map<List<GetExpiredReservationsResponse>>(entities);
                return response;
            }
        }
    }
}
