using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Pricings.Queries.GetById
{
    public class GetByIdPricingQuery : IRequest<GetByIdPricingResponse>
    {
        public int Id { get; set; }

        public GetByIdPricingQuery(int id)
        {
            Id = id;
        }

        public class GetByIdPricingQueryHandler : IRequestHandler<GetByIdPricingQuery, GetByIdPricingResponse>
        {
            private readonly IRepository<Pricing> _repository;
            private readonly IMapper _mapper;

            public GetByIdPricingQueryHandler(IRepository<Pricing> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdPricingResponse> Handle(GetByIdPricingQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdPricingResponse>(entity);
                return response;
            }
        }
    }
}
