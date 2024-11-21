using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Abouts.Queries.GetList
{
    public class GetListAboutQuery : IRequest<List<GetListAboutResponse>>
    {
        public class GetListAboutQueryHandler : IRequestHandler<GetListAboutQuery, List<GetListAboutResponse>>
        {
            private readonly IRepository<About> _repository;
            private readonly IMapper _mapper;

            public GetListAboutQueryHandler(IRepository<About> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListAboutResponse>> Handle(GetListAboutQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListAboutResponse>>(entities);
                return response;
            }
        }

    }
}


