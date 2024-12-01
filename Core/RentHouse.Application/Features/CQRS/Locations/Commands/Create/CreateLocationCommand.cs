using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Locations.Commands.Create
{
	public class CreateLocationCommand : IRequest
	{
		public int LocationID { get; set; }
		public string Name { get; set; }

		public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
		{
			private readonly IRepository<Location> _repository;
			private readonly IMapper _mapper;
			public CreateLocationCommandHandler(IRepository<Location> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateLocationCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<Location>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
