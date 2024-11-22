using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Settings.CQRS.Settings.Queries.GetById
{
    public class GetByIdSettingQuery : IRequest<GetByIdSettingResponse>
    {
        public int Id { get; set; }

        public GetByIdSettingQuery(int id)
        {
            Id = id;
        }

        public class GetByIdSettingQueryHandler : IRequestHandler<GetByIdSettingQuery, GetByIdSettingResponse>
        {
            private readonly IRepository<Setting> _repository;
            private readonly IMapper _mapper;

            public GetByIdSettingQueryHandler(IRepository<Setting> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdSettingResponse> Handle(GetByIdSettingQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdSettingResponse>(entity);
                return response;
            }
        }
    }
}
