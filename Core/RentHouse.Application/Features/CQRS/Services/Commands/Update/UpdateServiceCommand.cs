using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Services.Commands.Update
{
    public class UpdateServiceCommand : IRequest
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

        public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
        {
            private readonly IRepository<Service> _repository;
            private readonly IMapper _mapper;

            public UpdateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.ServiceID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
