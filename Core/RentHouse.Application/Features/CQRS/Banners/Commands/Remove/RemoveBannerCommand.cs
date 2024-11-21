using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Banners.Commands.Remove
{
    public class RemoveBannerCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveBannerCommand(int id)
        {
            Id = id;
        }

        public class RemoveBannerCommandHandler : IRequestHandler<RemoveBannerCommand>
        {
            private readonly IRepository<Banner> _repository;

            public RemoveBannerCommandHandler(IRepository<Banner> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveBannerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
