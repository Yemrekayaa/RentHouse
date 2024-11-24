using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Reservations.Commands.Remove
{
	public class RemoveReservationCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveReservationCommand(int id)
		{
			Id = id;
		}

		public class RemoveReservationCommandHandler : IRequestHandler<RemoveReservationCommand>
		{
			private readonly IRepository<Reservation> _repository;

			public RemoveReservationCommandHandler(IRepository<Reservation> repository)
			{
				_repository = repository;
			}

			public async Task Handle(RemoveReservationCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				await _repository.RemoveAsync(entity);
			}
		}
	}
}
