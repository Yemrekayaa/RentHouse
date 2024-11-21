using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Contacts.Commands.Update
{
    public class UpdateContactCommand : IRequest
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendDate { get; set; }

        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
        {
            private readonly IRepository<Contact> _repository;
            private readonly IMapper _mapper;

            public UpdateContactCommandHandler(IRepository<Contact> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.ContactID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
