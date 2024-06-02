ARG DOTNET_RUNTIME=mcr.microsoft.com/dotnet/aspnet:8.0
ARG DOTNET_SDK=mcr.microsoft.com/dotnet/sdk:8.0

FROM ${DOTNET_RUNTIME} AS base
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
EXPOSE 8080
EXPOSE 80
EXPOSE 443

FROM ${DOTNET_SDK} AS build
WORKDIR /src
ENV ASPNETCORE_ENVIRONMENT=Development
COPY backend/RentBuddyBackend/RentBuddyBackend.csproj RentBuddyBackend.csproj
RUN dotnet restore RentBuddyBackend.csproj
RUN dotnet tool install --global dotnet-ef
ENTRYPOINT ["/root/.dotnet/tools/dotnet-ef", "database", "update"]
COPY . .
RUN dotnet build "RentBuddyBackend.csproj" -c $ASPNETCORE_ENVIRONMENT -o /app/build

FROM build AS publish
ENV ASPNETCORE_ENVIRONMENT=Development
RUN dotnet publish "RentBuddyBackend.csproj" -c $ASPNETCORE_ENVIRONMENT -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentBuddyBackend.dll"]
 