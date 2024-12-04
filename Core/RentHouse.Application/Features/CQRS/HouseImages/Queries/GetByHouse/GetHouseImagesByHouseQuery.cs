using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages.Queries.GetByHouse
{
    public class GetHouseImagesByHouseQuery : IRequest<List<GetHouseImagesByHouseResponse>>
    {
        public int houseId { get; set; }

        public GetHouseImagesByHouseQuery(int houseId)
        {
            this.houseId = houseId;
        }

        public class GetHouseImagesByHouseQueryHandler : IRequestHandler<GetHouseImagesByHouseQuery, List<GetHouseImagesByHouseResponse>>
        {
            private readonly IRepository<HouseImage> _repository;
            private readonly IMapper _mapper;

            public GetHouseImagesByHouseQueryHandler(IRepository<HouseImage> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetHouseImagesByHouseResponse>> Handle(GetHouseImagesByHouseQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetByFilterAsync(x => x.HouseID == request.houseId);
                var response = _mapper.Map<List<GetHouseImagesByHouseResponse>>(entities);
                return response;
            }
        }
    }
}
