using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Abouts.Commands.Update
{
    public class UpdateAboutCommand : IRequest
    {
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
        {
            private readonly IRepository<About> _repository;
            private readonly IMapper _mapper;

            public UpdateAboutCommandHandler(IRepository<About> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.AboutID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
