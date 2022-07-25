FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ValueReceiver/ValueReceiver.csproj", "ValueReceiver/"]
RUN dotnet restore "ValueReceiver/ValueReceiver.csproj"
COPY . .
WORKDIR "/src/ValueReceiver"
RUN dotnet build "ValueReceiver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ValueReceiver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ValueReceiver.dll"]
