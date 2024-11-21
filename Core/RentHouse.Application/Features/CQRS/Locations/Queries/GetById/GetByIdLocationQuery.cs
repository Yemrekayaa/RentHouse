using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations.Queries.GetById
{
    public class GetByIdLocationQuery : IRequest<GetByIdLocationResponse>
    {
        public int Id { get; set; }

        public GetByIdLocationQuery(int id)
        {
            Id = id;
        }

        public class GetByIdLocationQueryHandler : IRequestHandler<GetByIdLocationQuery, GetByIdLocationResponse>
        {
            private readonly IRepository<Location> _repository;
            private readonly IMapper _mapper;

            public GetByIdLocationQueryHandler(IRepository<Location> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdLocationResponse> Handle(GetByIdLocationQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdLocationResponse>(entity);
                return response;
            }
        }
    }
}
