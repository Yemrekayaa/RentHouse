using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Contacts.Queries.GetList
{
	public class GetListContactQuery : IRequest<List<GetListContactResponse>>
	{
		public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, List<GetListContactResponse>>
		{
			private readonly IRepository<Contact> _repository;
			private readonly IMapper _mapper;

			public GetListContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetListContactResponse>> Handle(GetListContactQuery request, CancellationToken cancellationToken)
			{
				var entities = await _repository.GetAllAsync();

				var response = _mapper.Map<List<GetListContactResponse>>(entities);
				return response;
			}
		}

	}
}


