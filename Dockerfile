# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY ./dotnet/ServiceOrderCreatorApi .
RUN dotnet restore
RUN dotnet publish -c Production -o /app/publish

# Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ServiceOrderCreatorApi.dll"]

# Keep container running
# ENTRYPOINT ["tail", "-f", "/dev/null"]