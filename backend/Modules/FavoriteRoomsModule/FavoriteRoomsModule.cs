using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.FavoriteRooms.Repository;
using RentBuddyBackend.Modules.FavoriteRooms.Service;

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
