using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.FavoriteUsersModule.Repository;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;

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
