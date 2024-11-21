using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
        {
            private readonly IRepository<Category> _repository;
            private readonly IMapper _mapper;

            public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.CategoryID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
