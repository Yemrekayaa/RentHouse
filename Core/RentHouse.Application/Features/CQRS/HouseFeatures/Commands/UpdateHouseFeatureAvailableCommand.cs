using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.HouseFeatures.Commands
{
    public class UpdateHouseFeatureAvailableCommand : IRequest
    {

        public int Id { get; set; }
        public bool Available { get; set; }
        public UpdateHouseFeatureAvailableCommand(int id, bool available)
        {
            Id = id;
            Available = available;
        }

        public class UpdateHouseFeatureAvailableCommandHandler : IRequestHandler<UpdateHouseFeatureAvailableCommand>
        {
            private readonly IHouseFeatureRepository _HouseFeatureRepository;
            private readonly IMapper _mapper;

            public UpdateHouseFeatureAvailableCommandHandler(IHouseFeatureRepository houseFeatureRepository, IMapper mapper)
            {
                _HouseFeatureRepository = houseFeatureRepository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateHouseFeatureAvailableCommand request, CancellationToken cancellationToken)
            {
                await _HouseFeatureRepository.ChangeAvailable(request.Id, request.Available);

            }
        }
    }
}
