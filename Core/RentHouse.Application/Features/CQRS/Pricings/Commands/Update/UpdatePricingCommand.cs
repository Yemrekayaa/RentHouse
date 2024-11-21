using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Pricings.Commands.Update
{
    public class UpdatePricingCommand : IRequest
    {
        public int PricingID { get; set; }
        public int HouseID { get; set; }
        public decimal WeekdayPrice { get; set; }
        public decimal WeekendPrice { get; set; }

        public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
        {
            private readonly IRepository<Pricing> _repository;
            private readonly IMapper _mapper;

            public UpdatePricingCommandHandler(IRepository<Pricing> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.PricingID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
