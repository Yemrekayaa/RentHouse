using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Services.Queries.GetList
{
    public class GetListServiceQuery : IRequest<List<GetListServiceResponse>>
    {
        public class GetListServiceQueryHandler : IRequestHandler<GetListServiceQuery, List<GetListServiceResponse>>
        {
            private readonly IRepository<Service> _repository;
            private readonly IMapper _mapper;

            public GetListServiceQueryHandler(IRepository<Service> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListServiceResponse>> Handle(GetListServiceQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListServiceResponse>>(entities);
                return response;
            }
        }

    }
}


