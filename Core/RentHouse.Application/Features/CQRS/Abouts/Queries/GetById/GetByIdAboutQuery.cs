using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Abouts.Queries.GetById
{
    public class GetByIdAboutQuery : IRequest<GetByIdAboutResponse>
    {
        public int Id { get; set; }

        public GetByIdAboutQuery(int id)
        {
            Id = id;
        }

        public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutResponse>
        {
            private readonly IRepository<About> _repository;
            private readonly IMapper _mapper;

            public GetByIdAboutQueryHandler(IRepository<About> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdAboutResponse> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdAboutResponse>(entity);
                return response;
            }
        }
    }
}
