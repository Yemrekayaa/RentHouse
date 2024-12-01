using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Contacts.Queries.GetById
{
	public class GetByIdContactQuery : IRequest<GetByIdContactResponse>
	{
		public int Id { get; set; }

		public GetByIdContactQuery(int id)
		{
			Id = id;
		}

		public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactResponse>
		{
			private readonly IRepository<Contact> _repository;
			private readonly IMapper _mapper;

			public GetByIdContactQueryHandler(IRepository<Contact> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdContactResponse> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdContactResponse>(entity);
				return response;
			}
		}
	}
}
