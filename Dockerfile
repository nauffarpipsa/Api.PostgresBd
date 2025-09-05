# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Api.PostgresDB.sln"
RUN dotnet publish "Api.PostgresDB/Api.PostgresDB.csproj" -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8030
ENTRYPOINT ["dotnet", "Api.PostgresDB.dll"]