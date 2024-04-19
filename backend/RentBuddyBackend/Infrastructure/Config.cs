namespace RentBuddyBackend.Infrastructure;

public class Config(bool isDev)
{
    public string DbConnectionString { get; } = isDev
        ? "Server=localhost;Database=RentBuddyDB;Port=5096;User Id=postgres;Password=1"
        : Environment.GetEnvironmentVariable("Connection");
}