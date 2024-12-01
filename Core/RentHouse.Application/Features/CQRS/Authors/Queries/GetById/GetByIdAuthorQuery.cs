using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Authors.Queries.GetById
{
	public class GetByIdAuthorQuery : IRequest<GetByIdAuthorResponse>
	{
		public int Id { get; set; }

		public GetByIdAuthorQuery(int id)
		{
			Id = id;
		}

		public class GetByIdAuthorQueryHandler : IRequestHandler<GetByIdAuthorQuery, GetByIdAuthorResponse>
		{
			private readonly IRepository<Author> _repository;
			private readonly IMapper _mapper;

			public GetByIdAuthorQueryHandler(IRepository<Author> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdAuthorResponse> Handle(GetByIdAuthorQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdAuthorResponse>(entity);
				return response;
			}
		}
	}
}
