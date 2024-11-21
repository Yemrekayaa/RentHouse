using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Authors.Commands.Remove
{
    public class RemoveAuthorCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveAuthorCommand(int id)
        {
            Id = id;
        }

        public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand>
        {
            private readonly IRepository<Author> _repository;

            public RemoveAuthorCommandHandler(IRepository<Author> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
