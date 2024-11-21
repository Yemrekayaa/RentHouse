using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Pricings.Queries.GetList
{
    public class GetListPricingQuery : IRequest<List<GetListPricingResponse>>
    {
        public class GetListPricingQueryHandler : IRequestHandler<GetListPricingQuery, List<GetListPricingResponse>>
        {
            private readonly IRepository<Pricing> _repository;
            private readonly IMapper _mapper;

            public GetListPricingQueryHandler(IRepository<Pricing> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListPricingResponse>> Handle(GetListPricingQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListPricingResponse>>(entities);
                return response;
            }
        }

    }
}


