using Microsoft.EntityFrameworkCore;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Infrastructure;

namespace RentBuddyBackend.DAL;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, Config config)
    : DbContext(options)
{
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<ApartmentEntity> Apartments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        optionsBuilder
            .UseLazyLoadingProxies()
            .UseNpgsql(config.DbConnectionString,
                builder => { builder.
                    EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null); });
        base.OnConfiguring(optionsBuilder);
    }
}