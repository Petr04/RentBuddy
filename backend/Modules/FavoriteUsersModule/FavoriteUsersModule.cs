using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.FavoriteUsersModule.Repository;
using RentBuddyBackend.Modules.FavoriteUsersModule.Service;

namespace RentBuddyBackend.Modules.FavoriteUsersModule
{
    public class FavoriteUsersModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IFavoriteUsersService, FavoriteUsersService>();
            services.AddScoped<IFavoriteUsersRepository, FavoriteUsersRepository>();
            services.AddAutoMapper(typeof(FavoriteUsersMapper));

            return services;
        }
    }
}
