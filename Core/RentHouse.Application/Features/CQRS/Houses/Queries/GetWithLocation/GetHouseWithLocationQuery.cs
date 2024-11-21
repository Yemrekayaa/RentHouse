using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocation
{
	public class GetHouseWithLocationQuery : IRequest<List<GetHouseWithLocationResponse>>
	{
		public int? Count { get; set; }

		public GetHouseWithLocationQuery(int? count)
		{
			Count = count;
		}

		public class GetHouseWithLocationQueryHander : IRequestHandler<GetHouseWithLocationQuery, List<GetHouseWithLocationResponse>>
		{
			private readonly IHouseRepository _HouseRepository;
			private readonly IMapper _mapper;

			public GetHouseWithLocationQueryHander(IHouseRepository HouseRepository, IMapper mapper)
			{
				_HouseRepository = HouseRepository;
				_mapper = mapper;
			}

			public async Task<List<GetHouseWithLocationResponse>> Handle(GetHouseWithLocationQuery request, CancellationToken cancellationToken)
			{
				var entities = await _HouseRepository.GetHouseListWithLocationAsync(request.Count);

				var response = _mapper.Map<List<GetHouseWithLocationResponse>>(entities);
				return response;
			}
		}
	}
}
