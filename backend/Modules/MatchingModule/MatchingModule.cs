using RentBuddyBackend.Infrastructure;

namespace RentBuddyBackend.Modules.MatchingModule;

public class MatchingModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IMatchingService, MatchingService>();

        return services;
    }
}