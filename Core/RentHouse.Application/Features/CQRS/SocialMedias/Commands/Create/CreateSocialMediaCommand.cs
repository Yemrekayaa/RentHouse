using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.SocialMedias.Commands.Create
{
	public class CreateSocialMediaCommand : IRequest
	{
		public string Name { get; set; }
		public string Url { get; set; }
		public string Icon { get; set; }

		public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
		{
			private readonly IRepository<SocialMedia> _repository;
			private readonly IMapper _mapper;
			public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<SocialMedia>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
