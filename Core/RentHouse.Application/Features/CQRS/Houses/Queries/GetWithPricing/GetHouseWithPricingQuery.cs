using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetWithPricing
{
    public class GetHouseWithPricingQuery : IRequest<List<GetHouseWithPricingResponse>>
    {
        public int? Count { get; set; }

        public GetHouseWithPricingQuery(int? count)
        {
            Count = count;
        }

        public class GetHouseWithLocationQueryHander : IRequestHandler<GetHouseWithPricingQuery, List<GetHouseWithPricingResponse>>
        {
            private readonly IHouseRepository _HouseRepository;
            private readonly IMapper _mapper;

            public GetHouseWithLocationQueryHander(IHouseRepository HouseRepository, IMapper mapper)
            {
                _HouseRepository = HouseRepository;
                _mapper = mapper;
            }

            public async Task<List<GetHouseWithPricingResponse>> Handle(GetHouseWithPricingQuery request, CancellationToken cancellationToken)
            {
                var entities = await _HouseRepository.GetHouseListWithPricingAsync(request.Count);

                var response = _mapper.Map<List<GetHouseWithPricingResponse>>(entities);
                return response;
            }
        }
    }
}
