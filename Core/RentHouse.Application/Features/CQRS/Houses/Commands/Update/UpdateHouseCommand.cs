using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Houses.Commands.Update
{
	public class UpdateHouseCommand : IRequest
	{
		public int HouseID { get; set; }
		public int LocationID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string CoverImageUrl { get; set; }
		public int Area { get; set; }
		public byte NumberOfRooms { get; set; }
		public byte NumberOfBeds { get; set; }
		public string BigImageUrl { get; set; }
		public decimal WeekdayPrice { get; set; }
		public decimal WeekendPrice { get; set; }
		public decimal Latitude { get; set; }
		public decimal Longitude { get; set; }


		public class UpdateHouseCommandHandler : IRequestHandler<UpdateHouseCommand>
		{
			private readonly IRepository<House> _repository;
			private readonly IMapper _mapper;

			public UpdateHouseCommandHandler(IRepository<House> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(UpdateHouseCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.HouseID);
				_mapper.Map(request, entity);
				await _repository.UpdateAsync(entity);
			}
		}
	}
}
