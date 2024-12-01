using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Contacts.Commands.Create
{
	public class CreateContactCommand : IRequest
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public DateTime SendDate { get; set; }

		public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
		{
			private readonly IRepository<Contact> _repository;
			private readonly IMapper _mapper;
			public CreateContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<Contact>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
