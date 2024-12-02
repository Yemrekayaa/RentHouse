using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;
namespace RentHouse.Application.Features.CQRS.HouseFeatures.Queries.GetById
{
    public class GetHouseFeatureByIdQuery : IRequest<GetHouseFeatureByIdResponse>
    {
        public int Id { get; set; }

        public GetHouseFeatureByIdQuery(int id)
        {
            Id = id;
        }

        public class GetHouseFeaturByHouseIdQueryHandler : IRequestHandler<GetHouseFeatureByIdQuery, GetHouseFeatureByIdResponse>
        {
            private readonly IRepository<HouseFeature> _repository;

            private readonly IMapper _mapper;

            public GetHouseFeaturByHouseIdQueryHandler(IRepository<HouseFeature> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetHouseFeatureByIdResponse> Handle(GetHouseFeatureByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);
                var response = _mapper.Map<GetHouseFeatureByIdResponse>(entity);
                return response;
            }
        }
    }
}
