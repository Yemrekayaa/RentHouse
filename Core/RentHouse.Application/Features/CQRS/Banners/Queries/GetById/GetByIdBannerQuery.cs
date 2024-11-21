using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Banners.Queries.GetById
{
    public class GetByIdBannerQuery : IRequest<GetByIdBannerResponse>
    {
        public int Id { get; set; }

        public GetByIdBannerQuery(int id)
        {
            Id = id;
        }

        public class GetByIdBannerQueryHandler : IRequestHandler<GetByIdBannerQuery, GetByIdBannerResponse>
        {
            private readonly IRepository<Banner> _repository;
            private readonly IMapper _mapper;

            public GetByIdBannerQueryHandler(IRepository<Banner> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdBannerResponse> Handle(GetByIdBannerQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdBannerResponse>(entity);
                return response;
            }
        }
    }
}
