using AutoMapper;
using MediatR;
using RentHouse.Application.Common.Pagination;
using RentHouse.Application.Common.Sort;
using RentHouse.Application.Features.Filters.Houses;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetList
{
    public class GetListHouseQuery : IRequest<PaginatedResult<GetListHouseResponse>>
    {
        public PaginationQuery PaginationQuery { get; }
        public SortingQuery SortQuery { get; }
        public HouseFilterByDateDto HouseFilterByDateDto { get; }

        public GetListHouseQuery(PaginationQuery paginationQuery, SortingQuery sortQuery, HouseFilterByDateDto houseFilterByDateDto)
        {
            PaginationQuery = paginationQuery;
            SortQuery = sortQuery;
            HouseFilterByDateDto = houseFilterByDateDto;
        }



        public class GetListHouseQueryHandler : IRequestHandler<GetListHouseQuery, PaginatedResult<GetListHouseResponse>>
        {
            private readonly IRepository<House> _repository;
            private readonly IMapper _mapper;

            public GetListHouseQueryHandler(IRepository<House> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<GetListHouseResponse>> Handle(GetListHouseQuery request, CancellationToken cancellationToken)
            {
                if (request.SortQuery.OrderBy == "Id")
                {
                    request.SortQuery.OrderBy = "HouseId";
                }

                var entities = await _repository.GetAllAsync();
                var totalCount = await _repository.GetCountAsync();
                var response = _mapper.Map<IEnumerable<GetListHouseResponse>>(entities);

                return new PaginatedResult<GetListHouseResponse>(response, totalCount, request.PaginationQuery.PageNumber, request.PaginationQuery.PageSize);
            }
        }

    }
}


