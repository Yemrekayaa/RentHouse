using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetById
{
    public class GetByIdHouseQuery : IRequest<GetByIdHouseResponse>
    {
        public int Id { get; set; }

        public GetByIdHouseQuery(int id)
        {
            Id = id;
        }

        public class GetByIdHouseQueryHandler : IRequestHandler<GetByIdHouseQuery, GetByIdHouseResponse>
        {
            private readonly IRepository<House> _repository;
            private readonly IMapper _mapper;

            public GetByIdHouseQueryHandler(IRepository<House> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdHouseResponse> Handle(GetByIdHouseQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdHouseResponse>(entity);
                return response;
            }
        }
    }
}
