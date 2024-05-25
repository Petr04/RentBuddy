using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.RoomModule.Repository;
using RentBuddyBackend.Modules.UserModule.Repository;

namespace RentBuddyBackend.Modules.RoomModule
{
    public class RoomModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IRoomRepository, RoomRepository>();
            return services;
        }
    }
}
