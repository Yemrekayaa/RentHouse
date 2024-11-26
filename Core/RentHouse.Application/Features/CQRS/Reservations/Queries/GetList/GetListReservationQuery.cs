using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetList
{
    public class GetListReservationQuery : IRequest<List<GetListReservationResponse>>
    {
        public class GetListReservationQueryHandler : IRequestHandler<GetListReservationQuery, List<GetListReservationResponse>>
        {
            private readonly IRepository<Reservation> _repository;
            private readonly IMapper _mapper;

            public GetListReservationQueryHandler(IRepository<Reservation> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListReservationResponse>> Handle(GetListReservationQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListReservationResponse>>(entities);
                return response;
            }
        }

    }
}


