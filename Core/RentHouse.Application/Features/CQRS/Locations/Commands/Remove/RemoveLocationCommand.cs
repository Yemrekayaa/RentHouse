using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations.Commands.Remove
{
	public class RemoveLocationCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveLocationCommand(int id)
		{
			Id = id;
		}

		public class RemoveLocationCommandHandler : IRequestHandler<RemoveLocationCommand>
		{
			private readonly IRepository<Location> _repository;

			public RemoveLocationCommandHandler(IRepository<Location> repository)
			{
				_repository = repository;
			}

			public async Task Handle(RemoveLocationCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				await _repository.RemoveAsync(entity);
			}
		}
	}
}
