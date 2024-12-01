using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Testimonials.Commands.Remove
{
	public class RemoveTestimonialCommand : IRequest
	{
		public int Id { get; set; }

		public RemoveTestimonialCommand(int id)
		{
			Id = id;
		}

		public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
		{
			private readonly IRepository<Testimonial> _repository;

			public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
			{
				_repository = repository;
			}

			public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
			{
				var entity = await _repository.GetByIdAsync(request.Id);

				await _repository.RemoveAsync(entity);
			}
		}
	}
}
