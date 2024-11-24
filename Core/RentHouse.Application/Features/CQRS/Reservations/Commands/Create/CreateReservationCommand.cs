using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Reservations.Commands.Create
{
	public class CreateReservationCommand : IRequest
	{
		public int HouseID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public string Notes { get; set; }
		public bool IsConfirmed { get; set; }

		public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
		{
			private readonly IRepository<Reservation> _repository;
			private readonly IMapper _mapper;
			public CreateReservationCommandHandler(IRepository<Reservation> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<Reservation>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
