using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetList
{
    public class GetListFooterAddressQuery : IRequest<List<GetListFooterAddressResponse>>
    {
        public class GetListFooterAddressQueryHandler : IRequestHandler<GetListFooterAddressQuery, List<GetListFooterAddressResponse>>
        {
            private readonly IRepository<FooterAddress> _repository;
            private readonly IMapper _mapper;

            public GetListFooterAddressQueryHandler(IRepository<FooterAddress> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListFooterAddressResponse>> Handle(GetListFooterAddressQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListFooterAddressResponse>>(entities);
                return response;
            }
        }

    }
}


