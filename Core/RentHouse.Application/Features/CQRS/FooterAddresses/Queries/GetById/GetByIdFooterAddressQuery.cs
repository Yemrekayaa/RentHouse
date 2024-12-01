using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.FooterAddresses.Queries.GetById
{
	public class GetByIdFooterAddressQuery : IRequest<GetByIdFooterAddressResponse>
	{
		public int Id { get; set; }

		public GetByIdFooterAddressQuery(int id)
		{
			Id = id;
		}

		public class GetByIdFooterAddressQueryHandler : IRequestHandler<GetByIdFooterAddressQuery, GetByIdFooterAddressResponse>
		{
			private readonly IRepository<FooterAddress> _repository;
			private readonly IMapper _mapper;

			public GetByIdFooterAddressQueryHandler(IRepository<FooterAddress> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdFooterAddressResponse> Handle(GetByIdFooterAddressQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdFooterAddressResponse>(entity);
				return response;
			}
		}
	}
}
