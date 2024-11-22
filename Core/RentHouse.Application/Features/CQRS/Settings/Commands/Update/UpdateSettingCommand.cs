using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Settings.CQRS.Settings.Commands.Update
{
    public class UpdateSettingCommand : IRequest
    {
        public int SettingID { get; set; }
        public int BannerID { get; set; }

        public class UpdateSettingCommandHandler : IRequestHandler<UpdateSettingCommand>
        {
            private readonly IRepository<Setting> _repository;
            private readonly IMapper _mapper;

            public UpdateSettingCommandHandler(IRepository<Setting> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.SettingID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
