#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5046
ENV ASPNETCORE_URLS=http://+:5046

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aqua.Api/Aqua.Api.csproj", "Aqua.Api/"]
COPY ["Aqua.Application/Aqua.Application.csproj", "Aqua.Application/"]
COPY ["Aqua.SqlServer/Aqua.SqlServer.csproj", "Aqua.SqlServer/"]
COPY ["Aqua.Domain.Sql/Aqua.Domain.Sql.csproj", "Aqua.Domain.Sql/"]
COPY ["Aqua.Persistence/Aqua.Persistence.csproj", "Aqua.Persistence/"]
RUN dotnet restore "Aqua.Api/Aqua.Api.csproj"
COPY . .
WORKDIR "/src/Aqua.Api"
RUN dotnet build "Aqua.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aqua.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aqua.Api.dll"]
# docker buildx build -f ./Aqua.Api/Dockerfile --platform linux/amd64 --push -t  millegalb/aqua.api:2.0.4 .