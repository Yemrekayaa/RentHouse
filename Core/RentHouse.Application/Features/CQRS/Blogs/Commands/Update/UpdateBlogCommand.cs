using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Blogs.Commands.Update
{
    public class UpdateBlogCommand : IRequest
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryID { get; set; }
        public string Description { get; set; }

        public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
        {
            private readonly IRepository<Blog> _repository;
            private readonly IMapper _mapper;

            public UpdateBlogCommandHandler(IRepository<Blog> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.BlogID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
