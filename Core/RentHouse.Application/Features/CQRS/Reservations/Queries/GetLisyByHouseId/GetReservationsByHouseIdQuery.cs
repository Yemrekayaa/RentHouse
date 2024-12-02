using AutoMapper;
using MediatR;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetLisyByHouseId
{
    public class GetReservationsByHouseIdQuery : IRequest<PaginatedResult<GetReservationsByHouseIdResponse>>
    {
        public int Id { get; set; }
        public PaginationQuery Pagination { get; set; }

        public GetReservationsByHouseIdQuery(int id, PaginationQuery pagination)
        {
            Id = id;
            Pagination = pagination;
        }

        public class GetByIdReservationQueryHandler : IRequestHandler<GetReservationsByHouseIdQuery, PaginatedResult<GetReservationsByHouseIdResponse>>
        {
            private readonly IReservationRepository _repository;
            private readonly IMapper _mapper;

            public GetByIdReservationQueryHandler(IReservationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<GetReservationsByHouseIdResponse>> Handle(GetReservationsByHouseIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetListWithHouseByHouse(request.Id, request.Pagination);
                var totalCount = await _repository.GetWithHouseByHouseCount(request.Id);
                var response = _mapper.Map<IEnumerable<GetReservationsByHouseIdResponse>>(entity);

                return new PaginatedResult<GetReservationsByHouseIdResponse>(response, totalCount, request.Pagination.PageNumber, request.Pagination.PageSize);
            }
        }
    }
}
