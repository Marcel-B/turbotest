FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/Mqtt.ServR/Mqtt.ServR.csproj", "Mqtt.ServR/"]
RUN dotnet restore "Backend/Mqtt.ServR/Mqtt.ServR.csproj"
COPY . .
WORKDIR "/src/Mqtt.ServR"
RUN dotnet build "Mqtt.ServR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mqtt.ServR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mqtt.ServR.dll"]
