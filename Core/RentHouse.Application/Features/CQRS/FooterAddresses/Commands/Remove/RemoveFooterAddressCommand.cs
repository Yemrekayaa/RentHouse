using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Remove
{
    public class RemoveFooterAddressCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveFooterAddressCommand(int id)
        {
            Id = id;
        }

        public class RemoveFooterAddressCommandHandler : IRequestHandler<RemoveFooterAddressCommand>
        {
            private readonly IRepository<FooterAddress> _repository;

            public RemoveFooterAddressCommandHandler(IRepository<FooterAddress> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveFooterAddressCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
