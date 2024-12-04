using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.HouseImages.Queries.GetById
{
    public class GetByIdHouseImageQuery : IRequest<GetByIdHouseImageResponse>
    {
        public int Id { get; set; }

        public GetByIdHouseImageQuery(int id)
        {
            Id = id;
        }

        public class GetByIdHouseImageQueryHandler : IRequestHandler<GetByIdHouseImageQuery, GetByIdHouseImageResponse>
        {
            private readonly IRepository<HouseImage> _repository;
            private readonly IMapper _mapper;

            public GetByIdHouseImageQueryHandler(IRepository<HouseImage> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<GetByIdHouseImageResponse> Handle(GetByIdHouseImageQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdHouseImageResponse>(entity);
                return response;
            }
        }
    }
}
