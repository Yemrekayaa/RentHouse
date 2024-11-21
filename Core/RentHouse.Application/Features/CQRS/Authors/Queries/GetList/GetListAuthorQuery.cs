using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Authors.Queries.GetList
{
    public class GetListAuthorQuery : IRequest<List<GetListAuthorResponse>>
    {
        public class GetListAuthorQueryHandler : IRequestHandler<GetListAuthorQuery, List<GetListAuthorResponse>>
        {
            private readonly IRepository<Author> _repository;
            private readonly IMapper _mapper;

            public GetListAuthorQueryHandler(IRepository<Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListAuthorResponse>> Handle(GetListAuthorQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListAuthorResponse>>(entities);
                return response;
            }
        }

    }
}


