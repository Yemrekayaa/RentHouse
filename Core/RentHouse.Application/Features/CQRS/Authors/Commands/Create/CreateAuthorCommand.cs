using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Authors.Commands.Create
{
    public class CreateAuthorCommand : IRequest
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
        {
            private readonly IRepository<Author> _repository;
            private readonly IMapper _mapper;
            public CreateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Author>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
