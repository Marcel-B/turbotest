FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aqua.Web/Aqua.Web.csproj", "Aqua.Web/"]
RUN dotnet restore "Aqua.Web/Aqua.Web.csproj"
COPY . .
WORKDIR "/src/Aqua.Web"
RUN dotnet build "Aqua.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aqua.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aqua.Web.dll"]

# docker buildx build -f ./Aqua.Web/Dockerfile --platform linux/amd64 --push -t  millegalb/aqua.web:2.0.12 .