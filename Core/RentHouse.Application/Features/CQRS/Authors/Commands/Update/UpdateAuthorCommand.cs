using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Authors.Commands.Update
{
	public class UpdateAuthorCommand : IRequest
	{
		public int AuthorID { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
		public string Description { get; set; }

		public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
		{
			private readonly IRepository<Author> _repository;
			private readonly IMapper _mapper;

			public UpdateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
			{
				_repository = repository;
				_mapper = mapper;
			}

			public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.AuthorID);
				_mapper.Map(request, entity);
				await _repository.UpdateAsync(entity);
			}
		}
	}
}
