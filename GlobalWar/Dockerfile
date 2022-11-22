FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["GlobalWar/GlobalWar.csproj", "GlobalWar/"]
RUN dotnet restore "GlobalWar/GlobalWar.csproj"
COPY . .
WORKDIR "/src/GlobalWar"
RUN dotnet build "GlobalWar.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GlobalWar.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlobalWar.dll"]
