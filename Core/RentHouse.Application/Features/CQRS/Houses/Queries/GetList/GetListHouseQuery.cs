using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetList
{
    public class GetListHouseQuery : IRequest<List<GetListHouseResponse>>
    {
        public class GetListHouseQueryHandler : IRequestHandler<GetListHouseQuery, List<GetListHouseResponse>>
        {
            private readonly IRepository<House> _repository;
            private readonly IMapper _mapper;

            public GetListHouseQueryHandler(IRepository<House> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListHouseResponse>> Handle(GetListHouseQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListHouseResponse>>(entities);
                return response;
            }
        }

    }
}


