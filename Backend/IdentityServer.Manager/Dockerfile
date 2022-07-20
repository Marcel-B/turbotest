FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/IdentityServer.Manager/IdentityServer.Manager.csproj", "IdentityServer.Manager/"]
RUN dotnet restore "Backend/IdentityServer.Manager/IdentityServer.Manager.csproj"
COPY . .
WORKDIR "/src/IdentityServer.Manager"
RUN dotnet build "IdentityServer.Manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer.Manager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer.Manager.dll"]
