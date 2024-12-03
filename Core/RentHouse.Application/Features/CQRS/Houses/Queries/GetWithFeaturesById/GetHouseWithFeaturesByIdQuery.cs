using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetWithFeaturesById
{
    public class GetHouseWithFeaturesByIdQuery : IRequest<GetHouseWithFeaturesByIdResponse>
    {
        public int Id { get; set; }

        public GetHouseWithFeaturesByIdQuery(int id)
        {
            Id = id;
        }

        public class GetHouseWithFeaturesByIdQueryHandler : IRequestHandler<GetHouseWithFeaturesByIdQuery, GetHouseWithFeaturesByIdResponse>
        {
            private readonly IHouseRepository _houseRepository;
            private readonly IHouseFeatureRepository _houseFeatureRepository;
            private readonly IMapper _mapper;

            public GetHouseWithFeaturesByIdQueryHandler(IHouseRepository houseRepository, IMapper mapper, IHouseFeatureRepository houseFeatureRepository)
            {
                _houseRepository = houseRepository;
                _mapper = mapper;
                _houseFeatureRepository = houseFeatureRepository;
            }

            public async Task<GetHouseWithFeaturesByIdResponse> Handle(GetHouseWithFeaturesByIdQuery request, CancellationToken cancellationToken)
            {
                var houseResponse = await _houseRepository.GetHouseWithFeaturesByIdAsync(request.Id);



                var houseWithFeaturesResponse = _mapper.Map<GetHouseWithFeaturesByIdResponse>(houseResponse);


                return houseWithFeaturesResponse;
            }
        }
    }


}
