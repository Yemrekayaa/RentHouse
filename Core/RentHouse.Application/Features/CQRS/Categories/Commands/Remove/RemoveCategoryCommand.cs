using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Categories.Commands.Remove
{
    public class RemoveCategoryCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCategoryCommand(int id)
        {
            Id = id;
        }

        public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
        {
            private readonly IRepository<Category> _repository;

            public RemoveCategoryCommandHandler(IRepository<Category> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
