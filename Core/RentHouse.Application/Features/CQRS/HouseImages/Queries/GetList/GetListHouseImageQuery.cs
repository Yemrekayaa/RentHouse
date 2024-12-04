using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages.Queries.GetList
{
    public class GetListHouseImageQuery : IRequest<List<GetListHouseImageResponse>>
    {
        public class GetListHouseImageQueryHandler : IRequestHandler<GetListHouseImageQuery, List<GetListHouseImageResponse>>
        {
            private readonly IRepository<HouseImage> _repository;
            private readonly IMapper _mapper;

            public GetListHouseImageQueryHandler(IRepository<HouseImage> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListHouseImageResponse>> Handle(GetListHouseImageQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListHouseImageResponse>>(entities);
                return response;
            }
        }

    }
}


