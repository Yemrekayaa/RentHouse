using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Settings.CQRS.Settings.Queries.GetList
{
    public class GetListSettingQuery : IRequest<List<GetListSettingResponse>>
    {
        public class GetListSettingQueryHandler : IRequestHandler<GetListSettingQuery, List<GetListSettingResponse>>
        {
            private readonly IRepository<Setting> _repository;
            private readonly IMapper _mapper;

            public GetListSettingQueryHandler(IRepository<Setting> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListSettingResponse>> Handle(GetListSettingQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListSettingResponse>>(entities);
                return response;
            }
        }

    }
}


