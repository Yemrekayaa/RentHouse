using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.SocialMedias.Queries.GetList
{
    public class GetListSocialMediaQuery : IRequest<List<GetListSocialMediaResponse>>
    {
        public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediaQuery, List<GetListSocialMediaResponse>>
        {
            private readonly IRepository<SocialMedia> _repository;
            private readonly IMapper _mapper;

            public GetListSocialMediaQueryHandler(IRepository<SocialMedia> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListSocialMediaResponse>> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListSocialMediaResponse>>(entities);
                return response;
            }
        }

    }
}


