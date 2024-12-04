using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages.Commands.Update
{
    public class UpdateHouseImageCommand : IRequest
    {
        public int HouseImageID { get; set; }
        public int HouseID { get; set; }
        public string ImageUrl { get; set; }

        public class UpdateHouseImageCommandHandler : IRequestHandler<UpdateHouseImageCommand>
        {
            private readonly IRepository<HouseImage> _repository;
            private readonly IMapper _mapper;

            public UpdateHouseImageCommandHandler(IRepository<HouseImage> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateHouseImageCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.HouseImageID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
