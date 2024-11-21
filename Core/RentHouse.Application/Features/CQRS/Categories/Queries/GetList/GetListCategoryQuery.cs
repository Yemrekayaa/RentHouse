using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Categories.Queries.GetList
{
    public class GetListCategoryQuery : IRequest<List<GetListCategoryResponse>>
    {
        public class GetListCategoryQueryHandler : IRequestHandler<GetListCategoryQuery, List<GetListCategoryResponse>>
        {
            private readonly IRepository<Category> _repository;
            private readonly IMapper _mapper;

            public GetListCategoryQueryHandler(IRepository<Category> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListCategoryResponse>> Handle(GetListCategoryQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListCategoryResponse>>(entities);
                return response;
            }
        }

    }
}


