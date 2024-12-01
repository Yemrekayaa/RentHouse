using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.FooterAddresses.Commands.Update
{
	public class UpdateFooterAddressCommand : IRequest
	{
		public int FooterAddressID { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
		{
			private readonly IRepository<FooterAddress> _repository;
			private readonly IMapper _mapper;

			public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.FooterAddressID);
				_mapper.Map(request, entity);
				await _repository.UpdateAsync(entity);
			}
		}
	}
}
