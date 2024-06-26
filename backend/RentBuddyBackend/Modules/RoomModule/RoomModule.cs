﻿using RentBuddyBackend.Infrastructure;
using RentBuddyBackend.Modules.RoomModule.Repository;

namespace RentBuddyBackend.Modules.RoomModule;

public class RoomModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddAutoMapper(typeof(RoomMapping));
            
        return services;
    }
}