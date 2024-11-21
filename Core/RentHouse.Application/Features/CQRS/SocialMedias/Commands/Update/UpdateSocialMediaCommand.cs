using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.SocialMedias.Commands.Update
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
        {
            private readonly IRepository<SocialMedia> _repository;
            private readonly IMapper _mapper;

            public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.SocialMediaID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
