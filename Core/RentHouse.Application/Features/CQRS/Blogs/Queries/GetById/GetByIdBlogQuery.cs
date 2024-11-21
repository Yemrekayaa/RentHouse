using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Blogs.Queries.GetById
{
    public class GetByIdBlogQuery : IRequest<GetByIdBlogResponse>
    {
        public int Id { get; set; }

        public GetByIdBlogQuery(int id)
        {
            Id = id;
        }

        public class GetByIdBlogQueryHandler : IRequestHandler<GetByIdBlogQuery, GetByIdBlogResponse>
        {
            private readonly IRepository<Blog> _repository;
            private readonly IMapper _mapper;

            public GetByIdBlogQueryHandler(IRepository<Blog> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdBlogResponse> Handle(GetByIdBlogQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdBlogResponse>(entity);
                return response;
            }
        }
    }
}
