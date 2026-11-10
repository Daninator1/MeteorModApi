FROM mcr.microsoft.com/dotnet/aspnet:11.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:11.0 AS publish
WORKDIR /src
COPY ["MeteorModApi/MeteorModApi.csproj", "MeteorModApi/"]
RUN dotnet restore "MeteorModApi/MeteorModApi.csproj"
COPY . .
WORKDIR "/src/MeteorModApi"
RUN dotnet publish "MeteorModApi.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
COPY --from=publish /app/publish .
RUN mkdir -p /app/data && chown $APP_UID /app/data
VOLUME /app/data
USER $APP_UID
ENTRYPOINT ["dotnet", "MeteorModApi.dll"]
