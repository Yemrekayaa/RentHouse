using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Create
{
	public class CreateFooterAddressCommand : IRequest
	{
		public string Description { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
		{
			private readonly IRepository<FooterAddress> _repository;
			private readonly IMapper _mapper;
			public CreateFooterAddressCommandHandler(IRepository<FooterAddress> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
			{
				var entity = _mapper.Map<FooterAddress>(request);
				await _repository.CreateAsync(entity);
			}
		}
	}
}
