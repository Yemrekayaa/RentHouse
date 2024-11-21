using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest
    {
        public string Name { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
        {
            private readonly IRepository<Category> _repository;
            private readonly IMapper _mapper;
            public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Category>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
