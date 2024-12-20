using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Features.Commands.Create
{
    public class CreateFeatureCommand : IRequest
    {
        public string Name { get; set; }

        public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
        {
            private readonly IRepository<Feature> _repository;
            private readonly IHouseFeatureRepository _houseFeatureRepository;
            private readonly IMapper _mapper;

            public CreateFeatureCommandHandler(IRepository<Feature> repository, IHouseFeatureRepository houseFeatureRepository, IMapper mapper)
            {
                _repository = repository;
                _houseFeatureRepository = houseFeatureRepository;
                _mapper = mapper;
            }

            public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Feature>(request);
                await _repository.CreateAsync(entity);
                await _houseFeatureRepository.AddFeatureToHousesAsync(entity);
            }
        }
    }
}
