FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS restore
WORKDIR /src
COPY ["TimeZone/TimeZone.csproj", "TimeZone/"]
RUN dotnet restore "TimeZone/TimeZone.csproj"

FROM restore AS build
COPY . .
WORKDIR "/src/TimeZone"
RUN dotnet build "TimeZone.csproj" -c Release -o /app/build

FROM restore AS watch
WORKDIR /src
COPY . .
WORKDIR "/src/TimeZone"
ENTRYPOINT ["dotnet", "watch", "run"]

FROM build AS publish
RUN dotnet publish "TimeZone.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TimeZone.dll"]
