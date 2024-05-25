﻿namespace RentBuddyBackend.Infrastructure;

public class Config(bool isDev)
{
        public string DbConnectionString { get; } = isDev
        ? "Server=rb-postgresdb;Database=RentBuddyDB;Port=5432;User Id=postgres;Password=1"
        : Environment.GetEnvironmentVariable("Connection");
        // Чтобы сделать миграцию - хост менять на localhost
        // Для работы в контейнере - rb-postgresdb
        
        public string JwtIssuer { get; } = isDev
                ? "RentBuddyApp"
                : Environment.GetEnvironmentVariable("JwtIssuer");
        
        public string JwtAudience { get; } = isDev
                ? "RentBuddyUsers"
                : Environment.GetEnvironmentVariable("JwtAudience");
        
        public string JwtKey { get; } = isDev
                ? "dKt3Y#9^3nTv%2GpB&y8U@C*#w!WqS"
                : Environment.GetEnvironmentVariable("JwtKey");
}