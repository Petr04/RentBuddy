﻿using System.Security.Cryptography;
using System.Text;
using System;

namespace RentBuddyBackend.Infrastructure;

public class Config(bool isDev)
{
    private static string PasswordSaltString = Environment.GetEnvironmentVariable("PASSWORD_SALT")
        ?? throw new ArgumentNullException("PASSWORD_SALT environment variable is not set");
    public byte[] PasswordSalt { get; } = new HMACSHA512(
        Encoding.ASCII.GetBytes(PasswordSaltString)).Key;

    private static string DbName = Environment.GetEnvironmentVariable("DB_NAME")
        ?? throw new ArgumentNullException("DB_NAME environment variable is not set");
    private static string DbHost = Environment.GetEnvironmentVariable("DB_HOST")
        ?? throw new ArgumentNullException("DB_HOST environment variable is not set");
    private static string DbUsername = Environment.GetEnvironmentVariable("DB_USERNAME")
        ?? throw new ArgumentNullException("DB_USERNAME environment variable is not set");
    private static string DbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD")
        ?? throw new ArgumentNullException("DB_PASSWORD environment variable is not set");

    public string DbConnectionString { get; } =
        $"Server=${DbHost};Database=${DbName};Port=5432;User Id=${DbUsername};Password=${DbPassword}";
    // Чтобы сделать миграцию - хост менять на localhost
    // Для работы в контейнере - rb-postgresdb

    public string JwtIssuer { get; } = "RentBuddyApp";

    public string JwtAudience { get; } = "RentBuddyUsers";

    public string JwtKey { get; } = Environment.GetEnvironmentVariable("JWT_KEY") ?? "";
}