using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Pricings.Commands.Remove
{
    public class RemovePricingCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePricingCommand(int id)
        {
            Id = id;
        }

        public class RemovePricingCommandHandler : IRequestHandler<RemovePricingCommand>
        {
            private readonly IRepository<Pricing> _repository;

            public RemovePricingCommandHandler(IRepository<Pricing> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
