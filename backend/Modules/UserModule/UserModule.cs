using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.UserModule.Repository;
using RentBuddyBackend.Modules.UserModule.Service;

namespace RentBuddyBackend.Modules.UserModule
{
    public class UserModule : IModule
    {
        public IServiceCollection RegisterModule(IServiceCollection services)
        {   
           
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<AuthService>();
            services.AddAutoMapper(typeof(UserMapping));

            return services;
        }
    }
}
