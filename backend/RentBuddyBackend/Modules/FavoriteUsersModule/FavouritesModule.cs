using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.BlacklistModule;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;
using RentBuddyBackend.Modules.FavoriteUsersModule.Repository;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    public class FavouritesModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddAutoMapper(typeof(FavoriteMapper));

            return services;
        }
    }
}
