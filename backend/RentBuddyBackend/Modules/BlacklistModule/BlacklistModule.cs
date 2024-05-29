using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.BlacklistModule.Repository;
using RentBuddyBackend.Modules.BlacklistModule.Service;

namespace RentBuddyBackend.Modules.BlacklistModule
{
    public class BlacklistModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {
            services.AddScoped<IBlackListService, BlacklistService>();
            services.AddScoped<IBlacklistRepository, BlacklistRepository>();
            services.AddAutoMapper(typeof(BlacklistMapper));

            return services;
        }
    }
}
