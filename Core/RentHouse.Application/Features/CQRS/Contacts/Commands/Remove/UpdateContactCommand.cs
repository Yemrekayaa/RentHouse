using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Contacts.Commands.Remove
{
    public class RemoveContactCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveContactCommand(int id)
        {
            Id = id;
        }

        public class RemoveContactCommandHandler : IRequestHandler<RemoveContactCommand>
        {
            private readonly IRepository<Contact> _repository;

            public RemoveContactCommandHandler(IRepository<Contact> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveContactCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
