using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.UserModule.Service;
using RentBuddyBackend.Modules.ApartmentModule.Repository;

namespace RentBuddyBackend.Modules.ApartmentModule
{
    public class ApartmentModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            return services;
        }
    }
}
