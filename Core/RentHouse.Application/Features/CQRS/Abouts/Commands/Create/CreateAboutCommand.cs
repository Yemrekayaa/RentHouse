using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Abouts.Commands.Create
{
	public class CreateAboutCommand : IRequest
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
		{
			private readonly IRepository<About> _repository;
			private readonly IMapper _mapper;
			public CreateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<About>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
