using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Settings.CQRS.Settings.Commands.Create
{
    public class CreateSettingCommand : IRequest
    {
        public int BannerID { get; set; }

        public class CreateSettingCommandHandler : IRequestHandler<CreateSettingCommand>
        {
            private readonly IRepository<Setting> _repository;
            private readonly IMapper _mapper;
            public CreateSettingCommandHandler(IRepository<Setting> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateSettingCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Setting>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
