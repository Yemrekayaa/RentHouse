using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations.Commands.Update
{
    public class UpdateLocationCommand : IRequest
    {
        public int LocationID { get; set; }
        public string Name { get; set; }

        public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
        {
            private readonly IRepository<Location> _repository;
            private readonly IMapper _mapper;

            public UpdateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.LocationID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
