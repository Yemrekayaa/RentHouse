namespace RentHouse.Persistence
{
    public static class PersistenceServiceRegistiration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSignalR();
            return services;
        }
    }
}
