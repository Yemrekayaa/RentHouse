using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.Reservations.Commands.Update
{
    public class UpdateReservationCommand : IRequest
    {
        public int ReservationID { get; set; }
        public int HouseID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Notes { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsNotified { get; set; } = false;
        public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
        {
            private readonly IRepository<Reservation> _repository;
            private readonly IMapper _mapper;

            public UpdateReservationCommandHandler(IRepository<Reservation> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.ReservationID);
                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);
            }
        }
    }
}
