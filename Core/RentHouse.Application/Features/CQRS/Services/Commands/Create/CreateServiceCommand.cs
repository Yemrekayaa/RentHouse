using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Services.Commands.Create
{
	public class CreateServiceCommand : IRequest
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string IconUrl { get; set; }

		public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
		{
			private readonly IRepository<Service> _repository;
			private readonly IMapper _mapper;
			public CreateServiceCommandHandler(IRepository<Service> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateServiceCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<Service>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
