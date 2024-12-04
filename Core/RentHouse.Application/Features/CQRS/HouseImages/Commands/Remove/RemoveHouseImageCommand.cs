using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages.Commands.Remove
{
    public class RemoveHouseImageCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveHouseImageCommand(int id)
        {
            Id = id;
        }

        public class RemoveHouseImageCommandHandler : IRequestHandler<RemoveHouseImageCommand>
        {
            private readonly IRepository<HouseImage> _repository;

            public RemoveHouseImageCommandHandler(IRepository<HouseImage> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveHouseImageCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
