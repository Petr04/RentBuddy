using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.UserModule.Repository;
using RentBuddyBackend.Modules.UserModule.Service;
using RentBuddyBackend.Modules.UserModule;
using RentBuddyBackend.Modules.BlacklistModule.Service;
using RentBuddyBackend.Modules.BlacklistModule.Repository;

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
