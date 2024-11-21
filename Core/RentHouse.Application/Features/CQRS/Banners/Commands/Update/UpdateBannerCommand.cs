using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Banners.Commands.Update
{
    public class UpdateBannerCommand : IRequest
    {
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }

        public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
        {
            private readonly IRepository<Banner> _repository;
            private readonly IMapper _mapper;

            public UpdateBannerCommandHandler(IRepository<Banner> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.BannerID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
