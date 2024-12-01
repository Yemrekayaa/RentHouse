using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetById
{
	public class GetByIdSocialMediaQuery : IRequest<GetByIdSocialMediaResponse>
	{
		public int Id { get; set; }

		public GetByIdSocialMediaQuery(int id)
		{
			Id = id;
		}

		public class GetByIdSocialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, GetByIdSocialMediaResponse>
		{
			private readonly IRepository<SocialMedia> _repository;
			private readonly IMapper _mapper;

			public GetByIdSocialMediaQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<GetByIdSocialMediaResponse> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				var response = _mapper.Map<GetByIdSocialMediaResponse>(entity);
				return response;
			}
		}
	}
}
