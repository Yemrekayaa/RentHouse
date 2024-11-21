using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Pricings.Commands.Create
{
    public class CreatePricingCommand : IRequest
    {
        public int HouseID { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }

        public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
        {
            private readonly IRepository<Pricing> _repository;
            private readonly IMapper _mapper;
            public CreatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreatePricingCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Pricing>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
