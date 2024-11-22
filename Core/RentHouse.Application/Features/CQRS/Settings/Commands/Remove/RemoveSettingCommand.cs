using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Settings.CQRS.Settings.Commands.Remove
{
    public class RemoveSettingCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveSettingCommand(int id)
        {
            Id = id;
        }

        public class RemoveSettingCommandHandler : IRequestHandler<RemoveSettingCommand>
        {
            private readonly IRepository<Setting> _repository;

            public RemoveSettingCommandHandler(IRepository<Setting> repository)
            {
                _repository = repository;
            }

            public async Task Handle(RemoveSettingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                await _repository.RemoveAsync(entity);
            }
        }
    }
}
