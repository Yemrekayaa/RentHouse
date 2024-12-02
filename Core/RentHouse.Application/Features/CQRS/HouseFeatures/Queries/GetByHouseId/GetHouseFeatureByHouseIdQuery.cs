using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetByHouseId
{
    public class GetHouseFeatureByHouseIdQuery : IRequest<IEnumerable<GetHouseFeatureByHouseIdResponse>>
    {
        public int Id { get; set; }

        public GetHouseFeatureByHouseIdQuery(int id)
        {
            Id = id;
        }

        public class GetHouseFeaturByHouseIdQueryHandler : IRequestHandler<GetHouseFeatureByHouseIdQuery, IEnumerable<GetHouseFeatureByHouseIdResponse>>
        {
            private readonly IHouseFeatureRepository _repository;
            private readonly IMapper _mapper;

            public GetHouseFeaturByHouseIdQueryHandler(IHouseFeatureRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetHouseFeatureByHouseIdResponse>> Handle(GetHouseFeatureByHouseIdQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetByHouseId(request.Id);
                var response = _mapper.Map<IEnumerable<GetHouseFeatureByHouseIdResponse>>(entities);
                return response;
            }
        }
    }
}
