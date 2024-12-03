using AutoMapper;
using MediatR;
using RentHouse.Application.Common.HouseFeature;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Houses.Commands.Create
{
    public class UpdateHouseWithFeaturesCommand : IRequest
    {
        public int HouseId { get; set; }
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public string BigImageUrl { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<UpdateHouseFeatureDto> HouseFeatures { get; set; }

        public class UpdateHouseWithFeaturesCommandHandler : IRequestHandler<UpdateHouseWithFeaturesCommand>
        {
            private readonly IHouseRepository _houseRepository;
            private readonly IMapper _mapper;

            public UpdateHouseWithFeaturesCommandHandler(IHouseRepository houseRepository, IMapper mapper)
            {
                _houseRepository = houseRepository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateHouseWithFeaturesCommand request, CancellationToken cancellationToken)
            {
                var house = await _houseRepository.GetHouseWithFeaturesByIdAsync(request.HouseId);
                _mapper.Map(request, house);
                await _houseRepository.UpdateAsync(house);

            }
        }
    }
}