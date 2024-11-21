using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Services.Commands.Remove
{
    public class RemoveServiceCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveServiceCommand(int id)
        {
            Id = id;
        }

        public class RemoveServiceCommandHandler : IRequestHandler<RemoveServiceCommand>
        {
            private readonly IRepository<Service> _repository;

            public RemoveServiceCommandHandler(IRepository<Service> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveServiceCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
