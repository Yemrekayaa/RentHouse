using AutoMapper;
using MediatR;
using RentHouse.Application.Interfaces;
using RentHouse.Domain.Entities;

namespace RentHouse.Application.Features.CQRS.AppUsers.Queries
{
    public class GetCheckAppUserQuery : IRequest<GetCheckAppUserResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserResponse>
        {
            private readonly IRepository<AppUser> _appUserRepository;
            private readonly IRepository<AppRole> _appRoleRepository;
            private readonly IMapper _mapper;

            public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository, IMapper mapper)
            {
                _appUserRepository = appUserRepository;
                _appRoleRepository = appRoleRepository;
                _mapper = mapper;
            }

            public async Task<GetCheckAppUserResponse> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _appUserRepository
                    .GetByFilterSingleAsync(x => x.UserName == request.UserName && x.Password == request.Password);
                if (user == null)
                {
                    return new GetCheckAppUserResponse { IsExist = false };
                }

                var values = _mapper.Map<GetCheckAppUserResponse>(user);
                values.IsExist = true;
                values.Role = (await _appRoleRepository.GetByFilterSingleAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;

                return values;
            }
        }
    }
}