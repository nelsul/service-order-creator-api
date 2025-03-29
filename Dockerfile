# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
# COPY ./SOProjectApi .
# RUN dotnet restore
# RUN dotnet publish -c Development -o /app/publish

# Run
# FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
# WORKDIR /app
# COPY --from=build /app/publish .
# ENTRYPOINT ["dotnet", "SOProjectApi.dll"]

# Keep container running
ENTRYPOINT ["tail", "-f", "/dev/null"]