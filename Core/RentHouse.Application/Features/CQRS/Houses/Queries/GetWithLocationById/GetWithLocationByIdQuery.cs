using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Houses.Queries.GetWithLocationById
{
	public class GetHouseWithLocationByIdQuery : IRequest<GetHouseWithLocationByIdResponse>
	{
		public int Id { get; set; }

		public GetHouseWithLocationByIdQuery(int id)
		{
			Id = id;
		}

		public class GetHouseWithLocationByIdQueryHander : IRequestHandler<GetHouseWithLocationByIdQuery, GetHouseWithLocationByIdResponse>
		{
			private readonly IHouseRepository _HouseRepository;
			private readonly IMapper _mapper;

			public GetHouseWithLocationByIdQueryHander(IHouseRepository HouseRepository, IMapper mapper)
			{
				_HouseRepository = HouseRepository;
				_mapper = mapper;
			}

			public async Task<GetHouseWithLocationByIdResponse> Handle(GetHouseWithLocationByIdQuery request, CancellationToken cancellationToken)
			{
				var entities = await _HouseRepository.GetHouseWithLocationAsync(request.Id);

				var response = _mapper.Map<GetHouseWithLocationByIdResponse>(entities);
				return response;
			}
		}
	}
}
