using AutoMapper;
using MediatR;
using RentHouse.Application.Common.HouseFeature;
using RentHouse.Application.Features.CQRS.HouseImages.Queries.GetByHouse;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Commands.Create
{
    public class CreateHouseWithFeaturesCommand : IRequest
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public List<GetHouseImagesByHouseResponse> HouseImages { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<CreateHouseFeatureDto> HouseFeatures { get; set; }

        public class CreateHouseWithFeaturesCommandHandler : IRequestHandler<CreateHouseWithFeaturesCommand>
        {
            private readonly IHouseRepository _houseRepository;
            private readonly IRepository<HouseFeature> _houseFeatureRepository;
            private readonly IMapper _mapper;

            public CreateHouseWithFeaturesCommandHandler(IHouseRepository houseRepository, IRepository<HouseFeature> houseFeatureRepository, IMapper mapper)
            {
                _houseRepository = houseRepository;
                _houseFeatureRepository = houseFeatureRepository;
                _mapper = mapper;
            }

            public async Task Handle(CreateHouseWithFeaturesCommand request, CancellationToken cancellationToken)
            {
                var house = _mapper.Map<House>(request);

                var houseId = await _houseRepository.CreateAsync(house);

                //var houseFeatures = _mapper.Map<List<HouseFeature>>(request.HouseFeatures);
                //houseFeatures.ForEach(hf => hf.HouseId = houseId);

                //await _houseFeatureRepository.CreateRangeAsync(houseFeatures);
            }
        }
    }
}