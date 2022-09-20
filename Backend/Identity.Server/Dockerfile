FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 6065
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["Identity.Server/Identity.Server.csproj", "Identity.Server/"]
COPY ["Identity.Domain/Identity.Domain.csproj", "Identity.Domain/"]

RUN dotnet restore "Identity.Server/Identity.Server.csproj"

COPY . .

WORKDIR "/src/Identity.Server"
RUN dotnet build "Identity.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Server.dll"]

# docker buildx build -f ./Identity.Server/Dockerfile --platform linux/amd64 --push -t  millegalb/identity.server:0.0.1 .