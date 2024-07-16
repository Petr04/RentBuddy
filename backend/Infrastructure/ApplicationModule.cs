using Newtonsoft.Json;
using RentBuddyBackend.DAL;

namespace RentBuddyBackend.Infrastructure;

public class ApplicationModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        services.AddDbContext<ApplicationDbContext>();

        return services;
    }
}