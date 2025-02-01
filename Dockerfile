FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["MeteorModApi/MeteorModApi.csproj", "MeteorModApi/"]
RUN dotnet restore "MeteorModApi/MeteorModApi.csproj"
COPY . .
WORKDIR "/src/MeteorModApi"
RUN dotnet build "MeteorModApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeteorModApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
VOLUME /app/data
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeteorModApi.dll"]
