FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6060

ENV ASPNETCORE_URLS=http://+:6060

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web.Identity/Web.Identity.csproj", "Web.Identity/"]
RUN dotnet restore "Web.Identity/Web.Identity.csproj"
COPY . .
WORKDIR "/src/Web.Identity"
RUN dotnet build "Web.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Identity.dll"]
# docker buildx build -f ./Web.Identity/Dockerfile --platform linux/amd64 --push -t  millegalb/web.identity:2.0.6 .