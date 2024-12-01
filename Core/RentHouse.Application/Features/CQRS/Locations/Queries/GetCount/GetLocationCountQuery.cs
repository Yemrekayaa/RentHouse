using MediatR;
using RentHouse.Application.Features.CQRS.Locations.Queries.GetCountLocation;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations.Queries.GetCount
{
	public class GetLocationCountQuery : IRequest<GetLocationCountResponse>
	{
		public class GetLocationCountQueryHandler : IRequestHandler<GetLocationCountQuery, GetLocationCountResponse>
		{
			private readonly IRepository<Location> _repository;

			public GetLocationCountQueryHandler(IRepository<Location> repository)
			{
				_repository = repository;
			}


			public async Task<GetLocationCountResponse> Handle(GetLocationCountQuery request, CancellationToken cancellationToken)
			{
				var value = await _repository.GetCountAsync();
				return new GetLocationCountResponse { count = value };
			}

		}
	}
}
