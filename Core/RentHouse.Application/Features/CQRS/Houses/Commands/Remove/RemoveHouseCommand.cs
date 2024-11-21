using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Commands.Remove
{
    public class RemoveHouseCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveHouseCommand(int id)
        {
            Id = id;
        }

        public class RemoveHouseCommandHandler : IRequestHandler<RemoveHouseCommand>
        {
            private readonly IRepository<House> _repository;

            public RemoveHouseCommandHandler(IRepository<House> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveHouseCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
