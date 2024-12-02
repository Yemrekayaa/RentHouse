using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseFeatures.Commands
{
	public class CreateHouseFeatureByHouseCommand : IRequest
	{

		public int HouseId { get; set; }
		public int FeatureId { get; set; }
		public bool Available { get; set; }
		public CreateHouseFeatureByHouseCommand(int houseId, int featureId, bool available)
		{
			HouseId = houseId;
			FeatureId = featureId;
			Available = available;
		}

		public class CreateHouseFeatureByHouseCommandHandler : IRequestHandler<CreateHouseFeatureByHouseCommand>
		{
			private readonly IHouseFeatureRepository _houseFeatureRepository;
			private readonly IMapper _mapper;

			public CreateHouseFeatureByHouseCommandHandler(IHouseFeatureRepository houseFeatureRepository, IMapper mapper)
			{
				_houseFeatureRepository = houseFeatureRepository;
				_mapper = mapper;
			}

			public async Task Handle(CreateHouseFeatureByHouseCommand request, CancellationToken cancellationToken)
			{
				var value = _mapper.Map<HouseFeature>(request);
				await _houseFeatureRepository.CreateByHouse(value);
			}
		}
	}
}
