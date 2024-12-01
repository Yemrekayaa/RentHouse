using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Banners.Queries.GetList
{
	public class GetListBannerQuery : IRequest<List<GetListBannerResponse>>
	{
		public class GetListBannerQueryHandler : IRequestHandler<GetListBannerQuery, List<GetListBannerResponse>>
		{
			private readonly IRepository<Banner> _repository;
			private readonly IMapper _mapper;

			public GetListBannerQueryHandler(IRepository<Banner> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task<List<GetListBannerResponse>> Handle(GetListBannerQuery request, CancellationToken cancellationToken)
			{
				var entities = await _repository.GetAllAsync();

				var response = _mapper.Map<List<GetListBannerResponse>>(entities);
				return response;
			}
		}

	}
}


