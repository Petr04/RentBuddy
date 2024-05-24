using Microsoft.EntityFrameworkCore;
using RentBuddyBackend.DAL.Entities;
using RentBuddyBackend.Infrastructure;

namespace RentBuddyBackend.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<RoomEntity> Rooms { get; set; }
    public DbSet<ApartmentEntity> Apartments { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<BlacklistEntity> BlacklistEntities { get; set; }
    public DbSet<FavoriteUsersEntity> FavouritesEntities { get; set; }
    public DbSet<FavoriteRoomsEntity> FavoriteRoomsEntities { get; set; }
    private readonly Config config; 
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, Config config) : base(options)
    {
        this.config = config;
        //Database.Migrate();
        //Database.EnsureDeleted();

    }

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