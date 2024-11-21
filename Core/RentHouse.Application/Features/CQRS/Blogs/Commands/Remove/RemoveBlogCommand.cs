using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Blogs.Commands.Remove
{
    public class RemoveBlogCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int id)
        {
            Id = id;
        }

        public class RemoveBlogCommandHandler : IRequestHandler<RemoveBlogCommand>
        {
            private readonly IRepository<Blog> _repository;

            public RemoveBlogCommandHandler(IRepository<Blog> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveBlogCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
