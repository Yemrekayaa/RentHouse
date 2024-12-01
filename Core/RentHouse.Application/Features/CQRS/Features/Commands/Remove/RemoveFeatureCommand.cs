using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Features.Commands.Remove
{
	public class RemoveFeatureCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveFeatureCommand(int id)
		{
			Id = id;
		}

		public class RemoveFeatureCommandHandler : IRequestHandler<RemoveFeatureCommand>
		{
			private readonly IRepository<Feature> _repository;

			public RemoveFeatureCommandHandler(IRepository<Feature> repository)
			{
				_repository = repository;
			}

			public async Task Handle(RemoveFeatureCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				await _repository.RemoveAsync(entity);
			}
		}
	}
}
