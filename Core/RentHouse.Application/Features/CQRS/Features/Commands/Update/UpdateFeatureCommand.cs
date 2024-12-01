using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Features.Commands.Update
{
	public class UpdateFeatureCommand : IRequest
	{
		public int FeatureID { get; set; }
		public string Name { get; set; }

		public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
		{
			private readonly IRepository<Feature> _repository;
			private readonly IMapper _mapper;

			public UpdateFeatureCommandHandler(IRepository<Feature> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.FeatureID);
				_mapper.Map(request, entity);
				await _repository.UpdateAsync(entity);
			}
		}
	}
}
