using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Blogs.Queries.GetList
{
    public class GetListBlogQuery : IRequest<List<GetListBlogResponse>>
    {
        public class GetListBlogQueryHandler : IRequestHandler<GetListBlogQuery, List<GetListBlogResponse>>
        {
            private readonly IRepository<Blog> _repository;
            private readonly IMapper _mapper;

            public GetListBlogQueryHandler(IRepository<Blog> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<GetListBlogResponse>> Handle(GetListBlogQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAllAsync();

                var response = _mapper.Map<List<GetListBlogResponse>>(entities);
                return response;
            }
        }

    }
}


