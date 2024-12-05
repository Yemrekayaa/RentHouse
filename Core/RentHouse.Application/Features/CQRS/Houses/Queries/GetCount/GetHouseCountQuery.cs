using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetCount
{
    public class GetHouseCountQuery : IRequest<int>
    {
        public class GetHouseCountQueryHandler : IRequestHandler<GetHouseCountQuery, int>
        {
            private readonly IRepository<House> _repository;

            public GetHouseCountQueryHandler(IRepository<House> repository)
            {
                _repository = repository;
            }


            public async Task<int> Handle(GetHouseCountQuery request, CancellationToken cancellationToken)
            {
                var value = await _repository.GetCountAsync();
                return value;
            }

        }
    }
}
