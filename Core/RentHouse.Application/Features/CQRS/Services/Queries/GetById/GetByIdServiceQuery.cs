using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Services.Queries.GetById
{
    public class GetByIdServiceQuery : IRequest<GetByIdServiceResponse>
    {
        public int Id { get; set; }

        public GetByIdServiceQuery(int id)
        {
            Id = id;
        }

        public class GetByIdServiceQueryHandler : IRequestHandler<GetByIdServiceQuery, GetByIdServiceResponse>
        {
            private readonly IRepository<Service> _repository;
            private readonly IMapper _mapper;

            public GetByIdServiceQueryHandler(IRepository<Service> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdServiceResponse> Handle(GetByIdServiceQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdServiceResponse>(entity);
                return response;
            }
        }
    }
}
