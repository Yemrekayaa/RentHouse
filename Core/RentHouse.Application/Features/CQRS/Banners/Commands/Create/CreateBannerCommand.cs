using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Banners.Commands.Create
{
    public class CreateBannerCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }

        public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
        {
            private readonly IRepository<Banner> _repository;
            private readonly IMapper _mapper;
            public CreateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(CreateBannerCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Banner>(request);
                await _repository.CreateAsync(entity);
            }
        }
    }
}
