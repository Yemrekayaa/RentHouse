using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;

namespace RentHouse.Application.Features.CQRS.Blogs.Queries.GetListWithAuthor
{
    public class GetBlogListWithAuthorQuery : IRequest<List<GetBlogListWithAuthorResponse>>
    {
        public int? count { get; set; }

        public GetBlogListWithAuthorQuery(int? count)
        {
            this.count = count;
        }

        public class GetBlogListWithAuthorQueryHandler : IRequestHandler<GetBlogListWithAuthorQuery, List<GetBlogListWithAuthorResponse>>
        {
            private readonly IBlogRepository _blogRepository;
            private readonly IMapper _mapper;

            public GetBlogListWithAuthorQueryHandler(IBlogRepository blogRepository, IMapper mapper)
            {
                _blogRepository = blogRepository;
                _mapper = mapper;
            }

            public async Task<List<GetBlogListWithAuthorResponse>> Handle(GetBlogListWithAuthorQuery request, CancellationToken cancellationToken)
            {
                var entities = await _blogRepository.GetBlogsWithAuthorAsync(request.count);
                var response = _mapper.Map<List<GetBlogListWithAuthorResponse>>(entities);
                return response;
            }
        }
    }
}
