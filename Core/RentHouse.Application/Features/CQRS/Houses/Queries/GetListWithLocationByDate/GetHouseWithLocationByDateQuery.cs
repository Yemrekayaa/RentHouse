using AutoMapper;
using MediatR;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using RentHouse.Application.Features.Filters.Houses;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetListWithLocationByDate
{
    public class GetHouseWithLocationByDateQuery : IRequest<PaginatedResult<GetHouseWithLocationByDateResponse>>
    {
        public PaginationQuery PaginationQuery { get; }
        public SortingQuery SortQuery { get; }
        public HouseFilterByDateDto HouseFilterByDateDto { get; }

        public GetHouseWithLocationByDateQuery(PaginationQuery paginationQuery, SortingQuery sortQuery, HouseFilterByDateDto houseFilterByDateDto)
        {
            PaginationQuery = paginationQuery;
            SortQuery = sortQuery;
            HouseFilterByDateDto = houseFilterByDateDto;
        }



        public class GetHouseWithLocationByDateQueryHandler : IRequestHandler<GetHouseWithLocationByDateQuery, PaginatedResult<GetHouseWithLocationByDateResponse>>
        {
            private readonly IHouseRepository _repository;
            private readonly IMapper _mapper;

            public GetHouseWithLocationByDateQueryHandler(IHouseRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<GetHouseWithLocationByDateResponse>> Handle(GetHouseWithLocationByDateQuery request, CancellationToken cancellationToken)
            {
                if (request.SortQuery.OrderBy == "Id")
                {
                    request.SortQuery.OrderBy = "HouseId";
                }

                var entities = await _repository.GetAvailableHousesWithLocationAsync(request.HouseFilterByDateDto.StartDate, request.HouseFilterByDateDto.EndDate, request.PaginationQuery, request.SortQuery);
                var totalCount = await _repository.GetAvailableHousesWithLocationCountAsync(request.HouseFilterByDateDto.StartDate, request.HouseFilterByDateDto.EndDate);
                var response = _mapper.Map<IEnumerable<GetHouseWithLocationByDateResponse>>(entities);

                return new PaginatedResult<GetHouseWithLocationByDateResponse>(response, totalCount, request.PaginationQuery.PageNumber, request.PaginationQuery.PageSize);
            }
        }

    }
}


