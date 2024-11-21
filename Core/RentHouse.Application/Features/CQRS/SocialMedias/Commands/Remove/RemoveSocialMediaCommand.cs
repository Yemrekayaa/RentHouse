using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.SocialMedias.Commands.Remove
{
    public class RemoveSocialMediaCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSocialMediaCommand(int id)
        {
            Id = id;
        }

        public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
        {
            private readonly IRepository<SocialMedia> _repository;

            public RemoveSocialMediaCommandHandler(IRepository<SocialMedia> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
