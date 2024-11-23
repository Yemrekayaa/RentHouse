using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Commands.Create
{
    public class CreateHouseCommand : IRequest
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int Area { get; set; }
        public byte NumberOfRooms { get; set; }
        public byte NumberOfBeds { get; set; }
        public string BigImageUrl { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }

        public class CreateHouseCommandHandler : IRequestHandler<CreateHouseCommand>
        {
            private readonly IRepository<House> _repository;
            private readonly IMapper _mapper;
            public CreateHouseCommandHandler(IRepository<House> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateHouseCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<House>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
