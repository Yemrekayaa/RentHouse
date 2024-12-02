using AutoMapper;
using MediatR;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Reservations.Queries.GetListWithHouse
{
    public class GetReservationListWithHouseQuery : IRequest<PaginatedResult<GetReservationListWithHouseResponse>>
    {
        public PaginationQuery Pagination { get; set; }

        public GetReservationListWithHouseQuery(PaginationQuery pagination)
        {
            Pagination = pagination;
        }

        public class GetListReservationQueryHandler : IRequestHandler<GetReservationListWithHouseQuery, PaginatedResult<GetReservationListWithHouseResponse>>
        {
            private readonly IReservationRepository _repository;
            private readonly IMapper _mapper;

            public GetListReservationQueryHandler(IReservationRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<GetReservationListWithHouseResponse>> Handle(GetReservationListWithHouseQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetReservationListWithHouse(request.Pagination);
                var totalCount = await _repository.GetReservationListWithHouseCount();
                var response = _mapper.Map<IEnumerable<GetReservationListWithHouseResponse>>(entity);

                return new PaginatedResult<GetReservationListWithHouseResponse>(response, totalCount, request.Pagination.PageNumber, request.Pagination.PageSize);
            }
        }

    }
}


