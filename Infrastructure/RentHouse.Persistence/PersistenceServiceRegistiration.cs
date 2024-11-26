using Microsoft.Extensions.DependencyInjection;
using RentHouse.Application.Interfaces;
using RentHouse.Persistence.Context;
using RentHouse.Persistence.Repositories;

namespace RentHouse.Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<RentHouseContext>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            return services;
        }
    }
}
