#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG ASPNETCORE_ENVIRONMENT=Development
WORKDIR /src
COPY ["RentBuddyBackend/RentBuddyBackend.csproj", "RentBuddyBackend/"]
RUN dotnet restore "./RentBuddyBackend/RentBuddyBackend.csproj"
COPY . .
WORKDIR "/src/RentBuddyBackend"
RUN dotnet build "./RentBuddyBackend.csproj" -c $ASPNETCORE_ENVIRONMENT -o /app/build

FROM build AS publish
ARG ASPNETCORE_ENVIRONMENT=Development
RUN dotnet publish "./RentBuddyBackend.csproj" -c $ASPNETCORE_ENVIRONMENT -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentBuddyBackend.dll"]