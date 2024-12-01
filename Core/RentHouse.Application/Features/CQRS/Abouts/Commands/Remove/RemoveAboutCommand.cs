using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Abouts.Commands.Remove
{
	public class RemoveAboutCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveAboutCommand(int id)
		{
			Id = id;
		}

		public class RemoveAboutCommandHandler : IRequestHandler<RemoveAboutCommand>
		{
			private readonly IRepository<About> _repository;

			public RemoveAboutCommandHandler(IRepository<About> repository)
			{
				_repository = repository;
			}

			public async Task Handle(RemoveAboutCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				await _repository.RemoveAsync(entity);
			}
		}
	}
}
