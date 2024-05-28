using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.FavoriteUsersModule.Repository;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule;
using RentBuddyBackend.Modules.FavoriteRooms.Service;
using RentBuddyBackend.Modules.FavoriteRooms.Repository;

namespace RentBuddyBackend.Modules.FavoriteRoomsModule
{
    public class FavoriteRoomsModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IFavoriteRoomsService, FavoriteRoomsService>();
            services.AddScoped<IFavoriteRoomsRepository, FavoriteRoomsRepository>();

            return services;
        }
    }
}
