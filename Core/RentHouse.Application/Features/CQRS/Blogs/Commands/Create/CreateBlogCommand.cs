using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Blogs.Commands.Create
{
    public class CreateBlogCommand : IRequest
    {
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }

        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
        {
            private readonly IRepository<Blog> _repository;
            private readonly IMapper _mapper;
            public CreateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Blog>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
