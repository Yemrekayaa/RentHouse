using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages.Commands.Create
{
    public class CreateHouseImageCommand : IRequest
    {
        public int HouseID { get; set; }
        public string ImageUrl { get; set; }

        public class CreateHouseImageCommandHandler : IRequestHandler<CreateHouseImageCommand>
        {
            private readonly IRepository<HouseImage> _repository;
            private readonly IMapper _mapper;
            public CreateHouseImageCommandHandler(IRepository<HouseImage> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateHouseImageCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<HouseImage>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
